using IMS.BusinessLayer.IMSInterfaces;
using IMS.DataAccessLayer.IMSDatabase;
using IMS.DataAccessLayer.Interfaces;
using IMS.Models.IMS_Dtos;
using IMS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BusinessLayer.IMSClasses
{
    public class BatchBusinessAccess : IBatchBusinessAccess
    {
        private readonly IMS_IDataAccess<Batch> _batchRepo;
        private readonly IMS_IDataAccess<Faculty> _facultyRepo;
        private readonly IMS_IDataAccess<Course> _courseRepo;

        public BatchBusinessAccess(IMS_IDataAccess<Batch> batchRepo, IMS_IDataAccess<Faculty> facultyRepo, IMS_IDataAccess<Course> courseRepo)
        {
            _batchRepo = batchRepo;
            _facultyRepo = facultyRepo;
            _courseRepo = courseRepo;
        }

        //for Batch Table
        public async Task<List<Batch>> getAllBatchDetails()
        {
            
            {
                var data = await _batchRepo.GetAll();
                return data;
            }
            
        }

        public async Task<Response> BatchRegistration(BatchDto dto)
        {
            try
            {
                // Check if the provided CourseId exists in the repository
                bool courseIdExists = await _courseRepo.FindCourseId(dto.CourseId);

                // Check if the provided FacultyId exists in the repository
                bool facultyIdExists = await _facultyRepo.FindFacultyId(dto.FacultyId);

                if (courseIdExists && facultyIdExists)
                {
                    // Create a new Batch object using the BatchDto
                    Batch batch = new Batch
                    {
                        BatchName = dto.BatchName,
                        CourseId = dto.CourseId,
                        Timings = dto.Timings,
                        MaxStrength = dto.MaxStrength,
                        FacultyId = dto.FacultyId,
                        Status = dto.Status
                    };

                    // Add the batch to the repository
                    _batchRepo.Add(batch);

                    // Attempt to save changes
                    if (await _batchRepo.saveChnagesAsync())
                    {
                        // Batch and payment data saved successfully
                        return new Response(200, "OK", "Batch registration successful.", dto);
                    }
                    else
                    {
                        // Failed to save batch data
                        return new Response(500, "Internal Server Error", "Failed to save batch data");
                    }
                }
                else
                {
                    // Invalid CourseId or FacultyId
                    return new Response(400, "Bad Request", "Invalid CourseId or FacultyId");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> GetBatchByID(int id)
        {
            try
            {
                var data = await _batchRepo.GetById(id);
                if (data != null)
                {
                    return new Response(200, HttpStatusCode.OK.ToString(), " Data Fetched Successfully", data);
                }
                else
                {
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }
    }
}

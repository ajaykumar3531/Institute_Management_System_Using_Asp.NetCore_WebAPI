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
    public class FacultyBusinessAccess : IFacultyBusinessAccess
    {
        private readonly IMS_IDataAccess<Faculty> _facultyRepo;

        public FacultyBusinessAccess(IMS_IDataAccess<Faculty> facultyRepo)
        {
            _facultyRepo = facultyRepo;
        }

        // For Faculty
        public async Task<List<Faculty>> getAllFacultyDetails()
        {
            
            {
                // Retrieve all faculty data from the repository
                var facultyData = await _facultyRepo.GetAll();
                return facultyData;
            }
           
        }

        public async Task<Response> FacultyRegistration(FacultyDto dto)
        {
            try
            {
                // Check if faculty with the given email and mobile already exists
                var user = await _facultyRepo.FacultyByEmailAsync(dto.Email, dto.Mobile);

                if (user != null)
                {
                    // Faculty already exists
                    return new Response(400, "Bad Request", "Faculty already exists.");
                }
                else
                {
                    Faculty faculty = new Faculty()
                    {
                        FacultyName = dto.FacultyName,
                        YearsOfExperience = dto.YearsOfExperience,
                        Mobile = dto.Mobile,
                        Email = dto.Email,
                    };

                    // Add the faculty to the repository
                    _facultyRepo.Add(faculty);

                    // Attempt to save changes
                    if (await _facultyRepo.saveChnagesAsync())
                    {
                        // Faculty added successfully
                        return new Response(200, "OK", "Faculty Added successfully.", dto);
                    }
                    else
                    {
                        // Failed to add faculty
                        return new Response(500, "Internal Server Error", "Failed to Add faculty");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> GetFacultyByID(int id)
        {
            try
            {
                // Retrieve faculty data by ID from the repository
                var data = await _facultyRepo.GetById(id);
                if (data != null)
                {
                    // Faculty data fetched successfully
                    return new Response(200, HttpStatusCode.OK.ToString(), "Faculty Data Fetched Successfully", data);
                }
                else
                {
                    // Data not found
                    return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> DeleteFacultyData(int id)
        {
            try
            {
                // Retrieve faculty data by ID from the repository
                var data = await _facultyRepo.GetById(id);
                if (data != null)
                {
                    // Remove the faculty from the repository
                    _facultyRepo.Remove(data);
                    // Attempt to save changes
                    if (await _facultyRepo.saveChnagesAsync())
                    {
                        // Faculty data deleted successfully
                        return new Response(200, HttpStatusCode.OK.ToString(), "Faculty Data Deleted Successfully", data);
                    }
                }

                // Data not found
                return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, and return an appropriate response
                return new Response(500, "Internal Server Error", $"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response> UpdateFacultyData(FacultyUpdateDtp dto)
        {
            try
            {
                Faculty faculty = new Faculty()
                {
                    FacultyId = dto.Id,
                    FacultyName = dto.FacultyName,
                    YearsOfExperience = dto.YearsOfExperience,
                    Mobile = dto.Mobile,
                    Email = dto.Email,
                };

                // Update the faculty in the repository
                _facultyRepo.Update(faculty);

                // Attempt to save changes
                if (await _facultyRepo.saveChnagesAsync())
                {
                    // Faculty data updated successfully
                    return new Response(200, "OK", "Faculty Data Updated successfully.", dto);
                }
                else
                {
                    // Failed to update faculty data
                    return new Response(500, "Internal Server Error", "Failed to update Data.");
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

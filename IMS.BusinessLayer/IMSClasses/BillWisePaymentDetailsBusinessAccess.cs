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
    public class BillWisePaymentDetailsBusinessAccess : IBillWisePaymentDetailsBusinessAccess
    {

        private readonly IMS_IDataAccess<Course> _courseRepo;
        private readonly IMS_IDataAccess<Student> _studentRepo;
        private readonly IMS_IDataAccess<BillWisePaymentDetail> _billWisePaymentDetailRepo;
        private readonly IMS_IDataAccess<StudentBill> _studentBillRepo;
        private readonly IMS_IDataAccess<PaymentMode> _paymentModeRepo;

        public BillWisePaymentDetailsBusinessAccess(IMS_IDataAccess<Course> courseRepo, IMS_IDataAccess<Student> studentRepo, IMS_IDataAccess<BillWisePaymentDetail> billWisePaymentDetailRepo, IMS_IDataAccess<StudentBill> studentBillRepo, IMS_IDataAccess<PaymentMode> paymentModeRepo)
        {
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
            _billWisePaymentDetailRepo = billWisePaymentDetailRepo;
            _studentBillRepo = studentBillRepo;
            _paymentModeRepo = paymentModeRepo;
        }

        public async Task<List<BillWisePaymentDetail>> getAllBillsWiseDetails()
        {
            var data = await _billWisePaymentDetailRepo.GetAll();
            return data;
        }
        public async Task<Response> BillsWiseRegistration(BillWisePayemetDetailsDto dto)
        {

            try
            {

                bool courseIdExists = await _courseRepo.FindCourseId(dto.CourseId);
                bool studentIdExists = await _studentRepo.FindStudentId(dto.StudentId);
                bool paymnetModeIdExists = await _paymentModeRepo.FindPaymentModeId(dto.PaymentModeId);
                bool studentBillId = await _studentBillRepo.FindStudentBillId(dto.StudentBillId);

                if (courseIdExists && studentIdExists && paymnetModeIdExists && studentBillId)
                {

                    BillWisePaymentDetail data = new BillWisePaymentDetail()
                    {
                        AmountPaid = dto.AmountPaid,
                        StudentBillId = dto.StudentBillId,
                        DueDate = dto.DueDate,
                        StudentId = dto.StudentId,
                        CourseId = dto.CourseId,
                        PaymentModeId = dto.PaymentModeId,
                        CollectedBy = dto.CollectedBy,
                    };


                    _billWisePaymentDetailRepo.Add(data);

                    // Attempt to save changes
                    if (await _billWisePaymentDetailRepo.saveChnagesAsync())
                    {

                        return new Response(200, "OK", "Registration successful.", dto);
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
        public async Task<Response> GetBillsWiseByID(int id)
        {
            var data = await _billWisePaymentDetailRepo.GetById(id);
            if (data != null)
            {
                return new Response(200, HttpStatusCode.OK.ToString(), " Data Fetched Successfully", data);
            }
            else
            {
                return new Response(400, HttpStatusCode.BadRequest.ToString(), "Data Not Found");
            }
        }
    }
}

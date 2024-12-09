using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi_APP.Data;
using Taxi_APP.Models;

namespace Taxi_APP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> GetAllAppointments()
        {
            var response = new ServiceResponse<List<Appointment>>();

            try
            {
                var appointments = await _context.Appointments.ToListAsync();
                response.Data = appointments;
                response.Success = true;
                response.Message = "Appointments retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> AddAppointment(AppointmentDto appointmentDto)
        {
            var response = new ServiceResponse<List<Appointment>>();

            var appointment = new Appointment
            {
                Name = appointmentDto.Name,
                LastName = appointmentDto.LastName,
                Location = appointmentDto.Location,
                Age = appointmentDto.Age
            };

            try
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                response.Data = await _context.Appointments.ToListAsync();
                response.Success = true;
                response.Message = "Appointment created successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        // New Delete Action
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> DeleteAppointment(int id)
        {
            var response = new ServiceResponse<List<Appointment>>();

            try
            {
                // Find the appointment by ID
                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    response.Success = false;
                    response.Message = "Appointment not found.";
                    return NotFound(response);
                }

                // Remove the appointment from the database
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();

                // Return the updated list of appointments
                response.Data = await _context.Appointments.ToListAsync();
                response.Success = true;
                response.Message = "Appointment deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}

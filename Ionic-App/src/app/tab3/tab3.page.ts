import { Component, OnInit } from '@angular/core';
import { ContactService } from './contact.service';
import { Appointment } from './appointment.model';  // Import the Appointment interface

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit {
  isOpen = false; 
  name: string = '';
  lastName: string = '';
  location: string = '';
  age: number | null = null;
  listOfContactPersons: Appointment[] = [];  // List of appointments

  constructor(private contactService: ContactService) {}

  ngOnInit() {
    this.GetAllAppointments();
  }

  openModal() {
    this.isOpen = !this.isOpen;
  }

  addNewContactPerson() {
    if (!this.name || !this.lastName || !this.location || !this.age) {
      alert('Please fill all fields.');
      return;
    }

    const newContact: Appointment = {
      name: this.name,
      lastName: this.lastName,
      location: this.location,
      age: this.age
    };

    this.contactService.AddAppointment(newContact).subscribe(
      (response) => {
        console.log('Appointment added successfully:', response);
        this.GetAllAppointments();
        this.clearForm();
        this.openModal();
      },
      (error) => {
        console.error('Error adding appointment:', error);
      }
    );
  }


  GetAllAppointments() {
    this.contactService.GetAllAppointments().subscribe(
      (response) => {
        this.listOfContactPersons = response.data;  // Assuming response contains 'data'
      },
      (error) => {
        console.error('Error fetching appointments:', error);
      }
    );
  }

  deleteAppointment(appointmentId: number) {

    if (!appointmentId) {
      console.error("Invalid appointment ID");
      return;
    }
  
    this.contactService.DeleteAppointment(appointmentId).subscribe(
      (response) => {
        console.log('Appointment deleted successfully:', response);
        this.GetAllAppointments();
      },
      (error) => {
        console.error('Error deleting appointment:', error);
      }
    );
  }

  clearForm() {
    this.name = '';
    this.lastName = '';
    this.location = '';
    this.age = null;
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = 'https://localhost:7293/Appointments';

  constructor(private http: HttpClient) {}

  private getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('authToken'); // Retrieve token from localStorage
    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }

  GetAllAppointments(): Observable<any> {
    return this.http.get<any>(this.apiUrl, { headers: this.getAuthHeaders() });
  }

  AddAppointment(appointment: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, appointment, { headers: this.getAuthHeaders() });
  }

  DeleteAppointment(appointmentId: number): Observable<any> {
    const url = `${this.apiUrl}/${appointmentId}`;
    return this.http.delete(url, { headers: this.getAuthHeaders() });
  }
}

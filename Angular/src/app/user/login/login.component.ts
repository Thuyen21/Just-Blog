import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { AuthenticateService } from 'src/app/service/authenticate.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  userName = 'owner@example.com';
  password = 'Owner@123';
  jwt: any;

  constructor(private authenticateService: AuthenticateService) {}

  login = (form: NgForm) => {
    if (form.valid) {
      this.authenticateService
        .login(form.value.userName, form.value.password)
        .subscribe(
          (data: any) => {
            localStorage.setItem('jwt', data.token);
            window.location.href = '/';
          },
          (error: any) => {
            if (error.status == 400) {
              alert('Invalid username or password');
            } else {
              alert('Something went wrong');
            }
          }
        );
    } else {
      alert('Please enter valid data');
    }
  };

  ngOnInit(): void {}
}

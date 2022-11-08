import { AuthenticateService } from 'src/app/service/authenticate.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css'],
})
export class ClientComponent implements OnInit {
  constructor(private authenticateService: AuthenticateService) {}
  user: any;
  username: any;
  role: any;
  islogin: any;
  logout = () => {
    localStorage.removeItem('jwt');
    window.location.href = '/user/login';
  };
  ngOnInit(): void {
    if (localStorage.getItem('jwt') !== null) {
      this.islogin = true;
      this.user = this.authenticateService.parseJwt(
        localStorage.getItem('jwt')
      );
      this.username = this.user.unique_name;
      this.role = this.user.role;
    } else {
      window.location.href = '/user/login';
      this.islogin = false;
    }
  }
}

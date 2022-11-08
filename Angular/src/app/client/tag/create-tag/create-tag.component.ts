import { TagService } from 'src/app/service/tag.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-create-tag',
  templateUrl: './create-tag.component.html',
  styleUrls: ['./create-tag.component.css'],
})
export class CreateTagComponent implements OnInit {
  constructor(private tagService: TagService) {}

  name: string = '';
  urlSlug: string = '';
  description: string = '';
  ngOnInit(): void {}
  create = (form: NgForm) => {
    if (form.valid) {
      this.tagService.post(this.name, this.urlSlug, this.description).subscribe(
        (data: any) => {
          window.location.href = '/tag';
        },
        (error: any) => {
          if (error.status == 400) {
            alert('url Slug had been used');
          } else {
            alert('Something went wrong');
          }
        }
      );
    } else {
      alert('Please enter valid data');
    }
  };
}

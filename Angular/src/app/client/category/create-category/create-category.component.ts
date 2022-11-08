import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CategoryService } from 'src/app/service/category.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css'],
})
export class CreateCategoryComponent implements OnInit {
  constructor(private categoryService: CategoryService) {}
  name: string = '';
  urlSlug: string = '';
  description: string = '';
  ngOnInit(): void {}

  create = (form: NgForm) => {
    if (form.valid) {
      this.categoryService
        .post(this.name, this.urlSlug, this.description)
        .subscribe(
          (data: any) => {
            window.location.href = '/category';
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

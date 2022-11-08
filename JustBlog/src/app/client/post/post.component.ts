import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/model/post';
import { PostService } from 'src/app/service/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  constructor(private postService: PostService) {}
  posts: Post[] | undefined;

  ngOnInit(): void {
    this.postService.get().subscribe((data: Post[]) => {
      this.posts = data;
    });
  }
}

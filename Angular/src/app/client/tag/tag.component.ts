import { Component, OnInit } from '@angular/core';
import { Tag } from 'src/app/model/tag';
import { TagService } from 'src/app/service/tag.service';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.css'],
})
export class TagComponent implements OnInit {
  constructor(private tagService: TagService) {}
  tags: Tag[] | undefined;
  ngOnInit(): void {
    this.tagService.get().subscribe((data: Tag[]) => {
      this.tags = data;
    });
  }
}

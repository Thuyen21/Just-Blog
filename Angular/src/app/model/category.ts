import { Post } from './post';
import { Guid } from 'guid-typescript';

export interface Category {
  id: Guid;
  name: string;
  description: string;
  urlSlug: string;
  post: Guid[];
  postTitles: string[];
}

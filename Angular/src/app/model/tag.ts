import { Guid } from 'guid-typescript';
import { Post } from './post';

export interface Tag {
  id: Guid;
  name: string;
  description: string;
  urlSlug: string;
}

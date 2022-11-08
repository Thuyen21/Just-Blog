import { Guid } from 'guid-typescript';
import { Category } from './category';
import { Tag } from './tag';

export interface Post {
  id: Guid;
  title: string;
  shortDescription: string;
  description: string;
  urlSlug: string;
  content: string;
  published: boolean;
  postedOn: Date;
  modified: Date;
  categoryId: Guid;
  categoryName: string;
  tags: string[];
  viewCount: number;
  rateCount: number;
  totalRate: number;
  rate: number;
}

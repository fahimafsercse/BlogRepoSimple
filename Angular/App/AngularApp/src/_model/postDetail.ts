import { User } from './user';

export class PostDetail {
  id: number;
  totalComment: string;
  post: number;
  active: boolean;
  author: number;
  editor: number;
  modified: Date;
  createdP: Date;
  user: User;
  editUser: User;
  authorUser: User;
}

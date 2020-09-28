import { User } from './user';

export class CommentDetail {
  id: number;
  postDetaild_Id: number;
  comment: string;
  likeCount: number;
  dislikeCount: string;
  active: boolean;
  author: number;
  editor: number;
  modified: Date;
  isLiked: boolean;
  isDisLike:boolean;
  createdP: Date;
  user: User;
  editUser: User;
  authorUser: User;
}

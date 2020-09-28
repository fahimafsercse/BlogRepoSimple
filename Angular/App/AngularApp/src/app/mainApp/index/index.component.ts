import { Component, OnInit } from '@angular/core';
import { SocialBlogService } from '../../../_service/socialBlog.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  postList: any[];
  constructor(private service: SocialBlogService) { }
  
  ngOnInit(): void {


    this.service.GetAllPost().subscribe((data: any) => {
      this.postList = data.output;
      alert(this.postList);
    },
      error => {
        console.log(error);
      });
  }

}

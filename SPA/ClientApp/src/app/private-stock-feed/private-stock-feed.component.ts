import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-private-stock-feed',
  templateUrl: './private-stock-feed.component.html',
  styleUrls: ['./private-stock-feed.component.css']
})
export class PrivateStockFeedComponent implements OnInit {
  username: Observable<string>;

  constructor(private authorizeService: AuthorizeService) { }

  ngOnInit(): void {
    this.username = this.authorizeService.getUser()
      .pipe(map(u => u.name));
  }

}

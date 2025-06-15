import { Component, OnInit } from '@angular/core';
import { NotificationService, Notification } from './notification.service';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css'],
  imports: [CommonModule] 
})
export class NotificationComponent implements OnInit {
  notifications: Notification[] = [];

  constructor(private notificationService: NotificationService) { }

  ngOnInit() {
    this.notificationService.notifications$.subscribe(n => {
      this.notifications = n;
    });
  }
}

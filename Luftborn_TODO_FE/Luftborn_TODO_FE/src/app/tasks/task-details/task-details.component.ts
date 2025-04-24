import { Component, Inject, OnInit } from '@angular/core';
import { TaskDto } from '../tasks.model';
import { NgIf } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-task-details',
  standalone: true,
  imports: [NgIf],
  templateUrl: './task-details.component.html',
  styleUrl: './task-details.component.css',
})
export class TaskDetailsComponent implements OnInit {
  task: TaskDto = new TaskDto();

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: TaskDto,
    public matDialog: MatDialogRef<any>
  ) {}

  ngOnInit() {
    this.task = this.data;
  }
}

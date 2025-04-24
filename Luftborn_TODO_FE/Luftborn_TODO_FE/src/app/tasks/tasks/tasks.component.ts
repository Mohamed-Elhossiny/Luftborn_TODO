import { Component, inject, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { TasksService } from '../tasks.service';
import { TaskDto } from '../tasks.model';
import { MatDialog } from '@angular/material/dialog';
import { AddUpdateTaskComponent } from '../add-update-task/add-update-task.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { TaskDetailsComponent } from '../task-details/task-details.component';
@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css',
})
export class TasksComponent implements OnInit {
  //#region Variables
  displayedColumns: any = [
    'position',
    'title',
    'description',
    'status',
    'actions',
  ];
  dataSource: TaskDto[] = [];
  //#endRegion

  //#region Angular Life cycle hooks

  constructor(private tasksService: TasksService, private dialog: MatDialog) {}
  ngOnInit() {
    this.getAllTask();
  }
  //#endregion

  getAllTask() {
    this.tasksService.getAllTasks().subscribe((res: any) => {
      if (res) this.dataSource = res;
    });
  }
  createTask() {
    const dialogRef = this.dialog.open(AddUpdateTaskComponent, {
      width: '750px',
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.getAllTask();
      }
    });
  }
  openDetails(element: TaskDto) {
    const dialogRef = this.dialog.open(TaskDetailsComponent, {
      width: '750px',
      data: element,
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.getAllTask();
      }
    });
  }
  updateTask(element: TaskDto) {
    const dialogRef = this.dialog.open(AddUpdateTaskComponent, {
      width: '750px',
      data: element,
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.getAllTask();
      }
    });
  }
  deleteTask(id: number) {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
      width: '500px',
      data: {
        message: 'Are you sure you want to delete this task?',
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.tasksService.deleteTask(id).subscribe((res: any) => {
          this.getAllTask();
        });
      }
    });
  }
}

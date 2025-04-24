import { Component, Inject, inject } from '@angular/core';
import { TasksService } from '../tasks.service';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NgClass, NgIf } from '@angular/common';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogRef,
} from '@angular/material/dialog';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { TaskDto } from '../tasks.model';

@Component({
  selector: 'app-add-update-task',
  standalone: true,
  imports: [NgClass, NgIf, ReactiveFormsModule],
  templateUrl: './add-update-task.component.html',
  styleUrl: './add-update-task.component.css',
})
export class AddUpdateTaskComponent {
  //#region Variables
  taskForm!: FormGroup;
  //#endRegion

  //#region Angular Life cycle hooks

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: TaskDto,
    private tasksService: TasksService,
    private fb: FormBuilder,
    public matDialog: MatDialogRef<any>
  ) {}
  ngOnInit() {
    this.createFrom();
  }
  //#endregion

  createFrom() {
    this.taskForm = this.fb.group({
      title: [
        this.data?.title || '',
        [Validators.required, Validators.minLength(5)],
      ],
      description: [this.data?.description || '', Validators.required],
      isComplete: [this.data?.isComplete || false, Validators.required],
    });
  }
  addTask() {
    if (this.taskForm.valid) {
      const newTask = this.taskForm.value;
      this.tasksService.addTask(newTask).subscribe((res: any) => {
        this.matDialog.close(true);
      });
    }
  }

  updateTask() {
    if (this.taskForm.valid) {
      const task = this.taskForm.value;
      task.id = this.data.id;
      this.tasksService.updateTask(task).subscribe((res: any) => {
        this.matDialog.close(true);
      });
    }
  }
}

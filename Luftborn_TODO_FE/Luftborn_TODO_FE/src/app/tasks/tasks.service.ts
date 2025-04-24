import { Injectable } from '@angular/core';
import { EnvironmentApiService } from '../core/services/environment-api.service';
import { AddTaskDto, TaskDto } from './tasks.model';

@Injectable({
  providedIn: 'root',
})
export class TasksService extends EnvironmentApiService {
  getAllTasks() {
    return this.httpClient.get(`${this.baseApi}/tasks/GetTasks`);
  }

  addTask(model: AddTaskDto) {
    return this.httpClient.post(`${this.baseApi}/tasks/AddTask`, model);
  }

  deleteTask(id: number) {
    return this.httpClient.delete(`${this.baseApi}/tasks/DeleteTask?id=${id}`);
  }

  updateTask(model: TaskDto) {
    return this.httpClient.post(`${this.baseApi}/tasks/UpdateTask`, model);
  }
  getTaskById(id: number) {
    return this.httpClient.get('');
  }
}

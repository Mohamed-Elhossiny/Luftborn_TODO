import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'tasks',
    loadComponent: () =>
      import('./tasks/tasks/tasks.component').then((m) => m.TasksComponent),
  },
];

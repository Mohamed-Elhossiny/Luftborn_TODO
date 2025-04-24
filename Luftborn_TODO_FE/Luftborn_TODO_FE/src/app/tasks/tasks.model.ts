export class TaskDto {
  id: number = 0;
  title: string = '';
  description: string = '';
  isComplete: boolean = false;
}

export class AddTaskDto {
  title: string = '';
  description: string = '';
  IsComplete: boolean = false;
}

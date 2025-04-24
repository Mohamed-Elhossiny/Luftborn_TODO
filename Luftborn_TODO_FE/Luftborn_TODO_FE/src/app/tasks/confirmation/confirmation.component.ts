import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation',
  standalone: true,
  imports: [],
  templateUrl: './confirmation.component.html',
  styleUrl: './confirmation.component.css',
})
export class ConfirmationComponent {
  constructor(
    private matDialog: MatDialogRef<ConfirmationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { message: string }
  ) {}
  confirm() {
    this.matDialog.close(true);
  }
  close() {
    this.matDialog.close(false);
  }
}

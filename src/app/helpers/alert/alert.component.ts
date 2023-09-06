import { Component, Input } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
    selector: 'app-alert',
    templateUrl: './alert.component.html',
    styleUrls: ['./alert.component.css'],
    animations: [
        trigger('slideInFromRight', [
            state('void', style({ transform: 'translateX(100%)' })),
            state('*', style({ transform: 'translateX(0)' })),
            transition(':enter', animate('300ms ease-in')),
            transition(':leave', animate('300ms ease-out'))
        ])
    ]
})
export class AlertComponent {
    @Input() message!: string;
    @Input() type: 'success' | 'error' = 'success';

    showAlert = false;

    show() {
        this.showAlert = true;
        setTimeout(() => {
            this.showAlert = false;
          }, 3000);
    }

    hide() {
        this.showAlert = false;
    }
}
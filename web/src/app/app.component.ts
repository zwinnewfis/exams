import { Component, OnInit } from '@angular/core';
import { DataService } from './app.data.service';
const Template = require('./views/app.html');

export class Question {
  id: number;
  name: string;
  answers: Array<string>;
  selected: number;
}

export class Exam {
  id: number;
  name: string;
  questions: Array<Question>;
}

export class UserExam {
  userName: string;
  exam: Exam;
}

@Component({
  selector: 'my-app',
  providers: [DataService],
  templateUrl: Template
})

export class AppComponent implements OnInit {

  exams: Array<Exam>;
  selectedExam: Exam;
  showResults: boolean;
  result: string;

  userExam: UserExam = {
    userName: null,
    exam: null
  };

  constructor(private _dataService: DataService) { }

  ngOnInit() {
    this.getAllItems();
  }

  getAllItems(): void {
    this._dataService
      .GetAll()
      .then((exams: Exam[]) => {
        this.exams = exams;
      });
  }

  onSelect(exam: Exam): void {
    this._dataService
      .GetSingle(exam.id)
      .then((exam) => {
        this.selectedExam = exam;
      });
    this.showResults = false;
  }

  submitExam(): void {
    if (this.isExamCompleted()) {
      this.userExam.exam = this.selectedExam;
      this._dataService
        .Check(this.userExam)
        .then(result => {
          this.showResults = true;
          this.result = result;
        });
    }
  }

  isExamCompleted(): boolean {
    return this.selectedExam.questions.every((q) => <any>q.selected != "");
  }
}
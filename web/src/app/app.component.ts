import { Component } from '@angular/core';


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
  templateUrl: 'app/views/app.html'
})
export class AppComponent {

  selectedExam: Exam;
  showResults:boolean;
  result: string;

  userExam: UserExam = {
    userName: null,
    exam: null
  };

  onSelect(exam: Exam): void {
    this.selectedExam = exam;
    this.showResults = false;
  }

  submitExam(): void {
    if (this.isExamCompleted()) {
      this.showResults = true;
      this.result = "4";
    }
  }

  isExamCompleted(): boolean {
    return this.selectedExam.questions.every((q) => <any>q.selected != "");
  }

  exams: Array<Exam> = [
    {
      id: 1, name: "alamakota", questions: [
        {
          id: 0,
          name: "Test Qirstion 1",
          answers: [
            "aaa", "bbb", "ccc"
          ],
          selected: null
        },
        {
          id: 0,
          name: "Test Qirstion 2",
          answers: [
            "aaa", "bbb", "ccc"
          ],
          selected: null
        },
        {
          id: 0,
          name: "Test Qirstio22334444",
          answers: [
            "1111aaa", "bb12b", "ccc"
          ],
          selected: null
        }
      ]
    },
{
      id: 1, name: "alamakota2", questions: [
        {
          id: 0,
          name: "Test Qirstion 1",
          answers: [
            "aaa", "bbb", "ccc2"
          ],
          selected: null
        },
        {
          id: 0,
          name: "Test Qirstion 2",
          answers: [
            "aaa", "bb2b", "ccc"
          ],
          selected: null
        },
        {
          id: 0,
          name: "Test Qirstio22334444",
          answers: [
            "11121aaa", "bb12b", "ccc"
          ],
          selected: null
        }
      ]
    },
  ];
}
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IncomeService } from '../core/services/income.service';

@Component({
  selector: 'app-incomes',
  templateUrl: './incomes.component.html',
  styleUrls: ['./incomes.component.css']
})
export class IncomesComponent implements OnInit {

  userIncome:Income={
    amount:0,
    description:'',
    date:'',
    remarks:''
  };

  userId:number;
  userName:string;
  invalidInput:boolean=false;
  
  constructor(private router: Router,
    private route: ActivatedRoute,
    private incomeService:IncomeService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p => {
        this.userId = +p.get('id');
    });
    this.route.params.subscribe(p=>{this.userName = p['userName'] });
  }

  create(){
    this.incomeService.createIncome(this.userIncome, this.userId).subscribe((resp) =>
    {
      if (resp) {
        this.invalidInput = false;
        this.router.navigate([`${'User/'}${this.userId}`]);
      }

    },
    (err: any) => {
      this.invalidInput = true;
    }
    );
  }

}

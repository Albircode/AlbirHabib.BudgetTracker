import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExpenditureService } from '../core/services/expenditure.service';
import { IncomeService } from '../core/services/income.service';
import { UserService } from '../core/services/user.service';
import { UserDetails } from '../shared/models/userDetails';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  userDetails: UserDetails;

  userId: number;



  constructor(private route: ActivatedRoute, private userService:UserService, private incomeService:IncomeService, private expenditureService:ExpenditureService) { }



  ngOnInit(): void {

   this.getData();

  }



  getData(){

    this.route.paramMap.subscribe(

      p => {

        this.userId = +p.get('id');

        this.userService.getUserDetailsById(this.userId).subscribe((user)=>

        {

          this.userDetails = user;

        });

    });

  }
  deleteIncome(incomeId:number){

    this.incomeService.deleteIncomeById( incomeId);

  }



  deleteExpenditure(expId:number){

    this.expenditureService.deleteExpenditureById(expId);

  }

}
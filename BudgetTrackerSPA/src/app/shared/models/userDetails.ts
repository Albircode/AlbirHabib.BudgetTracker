export interface UserDetails {

    id:number;

    fullname: string;

    email: string;

    TotalIncomes: number;

    totalExpenditures: number;

    incomes: Income[];

    expenditures: Expenditure[];

  }

  

  interface Expenditure {

    id: number;

    userId: number;

    amount: number;

    description: string;

    expDate: string;

    remarks: string;

  }

  

  interface Income {

    id: number;

    userId: number;

    amount: number;

    description: string;

    incomeDate: string;

    remarks: string;

  }
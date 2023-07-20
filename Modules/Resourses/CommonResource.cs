namespace InternalApplication
{
    public class CommonResource
    {
        protected CommonResource() { }
        public const string DataFound = nameof(DataFound);
        public const string DataInsert = nameof(DataInsert);
        public const string DataNotInsert = nameof(DataNotInsert);
        public const string DataUpdate = nameof(DataUpdate);
        public const string DataNotUpdate = nameof(DataNotUpdate);
        public const string DataDelete = nameof(DataDelete);
        public const string DataNotDelete = nameof(DataNotDelete);
        public const string DataExist = nameof(DataExist);
        public const string DataNotFound = nameof(DataNotFound);
        public const string BadRequest = nameof(BadRequest);
        public const string UsernameRequired = nameof(UsernameRequired);
        public const string Password_Min_Requied = nameof(Password_Min_Requied);
        public const string Unauthorized = nameof(Unauthorized);
        public const string Internal_Server_Error = nameof(Internal_Server_Error);
        public const string Forbidden = nameof(Forbidden);
        public const string OCRFileUploadType = nameof(OCRFileUploadType);
        public const string LoginErrorMsg = nameof(LoginErrorMsg);
        public const string LoginSuccessMsg = nameof(LoginSuccessMsg);
        public const string AttendanceNotUpdated = nameof(AttendanceNotUpdated);

        public const string PanExisting = nameof(PanExisting);
        public const string AadharExisting = nameof(AadharExisting);

        public const string CUSTOMER_DATA_UPDATED = nameof(CUSTOMER_DATA_UPDATED);
        public const string CUSTOMER_DATA_INSERTED = nameof(CUSTOMER_DATA_INSERTED);
        public const string CUSTOMER_DATA_DELETED = nameof(CUSTOMER_DATA_DELETED);
        public const string CustomerVoucherIdNotFound = nameof(CustomerVoucherIdNotFound);
        public const string CustIdNotFound = nameof(CustIdNotFound);
        public const string VoucherIdNotFound = nameof(VoucherIdNotFound);
        public const string ApproveSuccess = nameof(ApproveSuccess);
        public const string UnableToGetData = nameof(UnableToGetData);


        public const string NomineeInserted = nameof(NomineeInserted);
        public const string NomineeUpdated = nameof(NomineeUpdated);

        public const string NomineeGuardianNotUpdated = nameof(NomineeGuardianNotUpdated);

        public const string NomineeGuardianNotFound = nameof(NomineeGuardianNotFound);
        public const string NomineeNotFound = nameof(NomineeNotFound);
  


        //Deposit
        public const string UnableTocreateAccount = nameof(UnableTocreateAccount);
        public const string Deposit = nameof(Deposit);
        public const string Interest = nameof(Interest);
        public const string Amount = nameof(Amount);
        public const string AmountNotMatching = nameof(AmountNotMatching);
        public const string AmountNotDebited = nameof(AmountNotDebited);
        public const string DepositDetailsNotFoundForTransferAccount = nameof(DepositDetailsNotFoundForTransferAccount);
        public const string TransferAccountGreateThenAvailableAmount = nameof(TransferAccountGreateThenAvailableAmount);
        public const string TransactionNotFound = nameof(TransactionNotFound);
        public const string TransferAmountNotEqualToShareAmount = nameof(TransferAmountNotEqualToShareAmount);

        public const string ChequeDetailsNotFound = nameof(ChequeDetailsNotFound);
        public const string ChequeAmountLesser = nameof(ChequeAmountLesser);

        //Savings
        public const string SavingAccountExists = nameof(SavingAccountExists);
        public const string SavingAccountNotExists = nameof(SavingAccountNotExists);
        public const string SavingsAccountCreated = nameof(SavingsAccountCreated);
        public const string SavingsAccountNotApprovedForTransaction = nameof(SavingsAccountNotApprovedForTransaction);

        public const string MinimumSavingsDepositAmount = nameof(MinimumSavingsDepositAmount);
        public const string MaximumSavingsDepositAmount = nameof(MaximumSavingsDepositAmount);

        public const string MinimumPaymentTypeAmount = nameof(MinimumPaymentTypeAmount);
        public const string MaximumPaymentTypeAmount = nameof(MaximumPaymentTypeAmount);

        //cumulative
        public const string CumulativeAccountCreated = nameof(CumulativeAccountCreated);
        public const string CumulativeAccountExists = nameof(CumulativeAccountExists);

        public const string MinimumCumulativeDepositAmount = nameof(MinimumCumulativeDepositAmount);
        public const string MaximumCumulativeDepositAmount = nameof(MaximumCumulativeDepositAmount);

        //reccuring
        public const string RecurringAccountCreated = nameof(RecurringAccountCreated);
        public const string RecurringAccountExists = nameof(RecurringAccountExists);

        public const string MinimumRecurringDepositAmount = nameof(MinimumRecurringDepositAmount);
        public const string MaximumRecurringDepositAmount = nameof(MaximumRecurringDepositAmount);

        public const string shareNotExists = nameof(shareNotExists);
        public const string DepositAmountNotEqaul = nameof(DepositAmountNotEqaul);

        public const string MinimumOneShare = nameof(MinimumOneShare);
        public const string MaximumTenShare = nameof(MaximumTenShare);

        //Fixed 
        public const string FDAccountCreated = nameof(FDAccountCreated);
        public const string FDAccountExists = nameof(FDAccountExists);

        public const string MinimumFDDepositAmount = nameof(MinimumSavingsDepositAmount);
        public const string MaximumFDDepositAmount = nameof(MaximumFDDepositAmount);

        public const string FileRequired = nameof(FileRequired);

        public const string CustomerNotApproved = nameof(CustomerNotApproved);
        public const string SavingsAccountNotApproved = nameof(SavingsAccountNotApproved);

        //Cheque
        public const string ChequeInsert = nameof(ChequeInsert);
        public const string ChequeNotFound = nameof(ChequeNotFound);
        public const string ChequeAlreadyApproved = nameof(ChequeAlreadyApproved);
        public const string UnableToUpdateCheque = nameof(UnableToUpdateCheque);
        public const string UpdatedCheque = nameof(UpdatedCheque);
        public const string DeleteCheque = nameof(DeleteCheque);
        public const string UpdatedChequeStatus = nameof(UpdatedChequeStatus);
        public const string ChequeApproved = nameof(ChequeApproved);
        public const string ChequeRejected = nameof(ChequeRejected);

        //Jewel Loan
        public const string JewelLoanAccountCreated = nameof(JewelLoanAccountCreated);
        public const string JewelLoanAmountExceed = nameof(JewelLoanAmountExceed);

        // Transaction
        public const string TranscationAdded = nameof(TranscationAdded);

        //Key Details
        public const string PreviousKeyNotFound = nameof(PreviousKeyNotFound);
        public const string KeyMoved = nameof(KeyMoved);

        //Attendance
        public const string AttendanceAdded = nameof(AttendanceAdded);
        public const string AttendanceNotAdded = nameof(AttendanceNotAdded);

    }
}

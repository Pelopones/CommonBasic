C++ (Qt 4.7.4)
void EflsAgreement::onModify( QSqlRecord & rec, SqlQueryModel::Action action, QVector< bool >& /*fieldChanged*/ )
{
	try
	{
		modAgreement->setActionOk(true);
		double penja_forgive = rec.value("penja_forgive").toDouble();
		
		...........................

		modAgreement->setValue(selAgreement->currentIndex().row(), "penja_forgive", penja_forgive);

		SqlParser qs;

		qs.bind( ":id_efls_agreement", rec.value("id_efls_agreement") );
		qs.bind( ":id_efls", rec.value("id_efls") );
		qs.bind( ":number", rec.value("number") );
				.............................
		qs.bind( ":id_people", rec.value("id_people") );
		qs.bind( ":id_efls_agreement_state", rec.value("id_efls_agreement_state") );

		if( action == SqlQueryModel::Insert || action == SqlQueryModel::Update )
			qs.prepare
				( 
				"EXEC pr_efls_agreement_mod "
				"   @id_efls_agreement  = :id_efls_agreement, "
				"   @id_efls            = :id_efls, "
				"   @number             = :number, "
				.....................................
				"	@id_efls_agreement_state = :id_efls_agreement_state "
				);
		else
			qs.prepare("EXEC pr_efls_agreement_del :id_efls_agreement");

		resultExecSql(qs.result());
	}
	catch ( QSqlError &er )
	{
		modAgreement->setActionOk(false);
		MessageBoxEx::critical ( this, er );
	}
}

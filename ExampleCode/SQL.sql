SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
IF object_id('pr_efls_agreement_mod') IS NOT NULL
	DROP PROCEDURE pr_efls_agreement_mod
GO
CREATE PROCEDURE pr_efls_agreement_mod
    @id_efls_agreement			int,
    @id_efls					int,
    @number						varchar(50),
    @date						datetime,
    @debt						bablo,
	..............
	@id_efls_agreement_state	int
AS 
BEGIN TRY
SET NOCOUNT ON
	-- Объвязка для транзакций
	DECLARE @tc int
	SET @tc = @@TRANCOUNT
	IF ( @tc > 0 )
		SAVE TRAN beg
	ELSE
		BEGIN TRAN

	IF ( @id_people IS NULL )
		RAISERROR ('Не выбран должник!', 16, 1 )

	..............
        
	DECLARE @Efls_flags TABLE
	(
		id_efls int,
		id_type_efls_flags int,
		date_beg datetime,
		date_end datetime
	)

	IF ( @id_efls_agreement IS NULL )
	BEGIN
		DECLARE @id_efls_flags  int
		DECLARE @penja          bablo

		INSERT INTO @Efls_flags
		( 
			id_efls, 
			id_type_efls_flags, 
			date_beg
		)
		SELECT 
			@id_efls, 
			mcf.id_type_efls_flags, 
			@date
		FROM Efls e
		JOIN vi_Addr_appart vaa ON e.id_addr_appart = vaa.id_addr_appart
		JOIN vi_Management_company_house mch 
		ON 
			vaa.id_addr_house = mch.id_addr_house 
			AND @date BETWEEN mch.date_beg AND mch.date_end
		JOIN Management_company_flags mcf ON mch.id_management_company = mcf.id_management_company
		WHERE e.id_efls = @id_efls
...............
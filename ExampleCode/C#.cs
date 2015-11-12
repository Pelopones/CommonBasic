public static SqlString getRateNormRule( SqlInt32 id_efls, SqlDateTime date_now, SqlInt32 ext )
{
			SqlString _null = new SqlString();

			Efls efls = JKXBase.jkxBase.eflsCache.getEfls(id_efls);
			if ( efls == null)
				return _null;
			
			List<EflsRoom> eflsRoomLive = efls.getEflsRoomHelper().getEflsRoomLive(date_now);

            List<People> peopleLive = efls.getPeopleHelper().getPeopleNow(date_now, true,
				PeopleEfls.TypePeopleEfls.ConstantReg,
				PeopleEfls.TypePeopleEfls.TemporaryReg,
				PeopleEfls.TypePeopleEfls.LiveWithoutReg);


			Addr appart = efls.getAddrAppart().getAddr();

		
			int numEflsRooms = eflsRoomLive.Count;
			int numPeopleLive = peopleLive.Count;


			AddrAttr elevator = appart.getAddrAttrHelper().getAppartAttrByAttr( AddrAttr.Attr.ELEVATOR, date_now ); // Лифт
			AddrAttr electric = appart.getAddrAttrHelper().getAppartAttrByAttr( AddrAttr.Attr.ELECTRIC_PLATE, date_now ); // Э.плита
			AddrAttr gas = appart.getAddrAttrHelper().getAppartAttrByAttr( AddrAttr.Attr.GAS_PLATE, date_now ); // Г.плита
            AddrAttr dormitory = appart.getAddrAttrHelper().getAppartAttrByAttr(AddrAttr.Attr.DORMITORY, date_now ); // Общага
            AddrAttr dormitory_kitch = appart.getAddrAttrHelper().getAppartAttrByAttr(AddrAttr.Attr.DORMITORY_KITCH, date_now ); // Общага с общ. кух.
            AddrAttr dormitory_washhouse = appart.getAddrAttrHelper().getAppartAttrByAttr(AddrAttr.Attr.DORMITORY_WASHHOUSE, date_now ); // Общ. с .общ. прачечной
................
}
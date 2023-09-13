using System.Collections.Generic;

namespace LiveSplit.OriDE {
	public class MasterAssets : SceneID {
		public MasterAssets() : base() { Name = "MasterAssets"; }
		public static SceneID SaveDescription = new SceneID("11111111111111111111111111111111");
		public static SceneID SeinInventory = new SceneID("444B746E7F7A0AE0CC208C40DE7CD9B1");
		public static SceneID PlatformMovement = new SceneID("4AA674A355CA54E9321AEAB78E4E5599");
		public static SceneID ScenesManager = new SceneID("4A5B886C02AC652324FC2FDD8ED513AB");
		public static SceneID SeinLevel = new SceneID("44D72845AB790E021CC526C2EEAC82A5");
		public static SceneID PlayerAbilities = new SceneID("4B417974465D2E6BE06A6D8DBD0F0BB3");
		public static SceneID SeinSoulFlame = new SceneID("4548C1A49142B7E7C26404C530CF0CAC");
		public static SceneID SeinDeathCounter = new SceneID("48B63153499A49ACEFDD874FE2C88CBC");
		public static SceneID GameTimer = new SceneID("454EE3A50EB0CBE41EEF281B35EB93A9");
		public static SceneID SeinHealthInfo = new SceneID("4544D2E4CB117A965E43AAEB8BFE26AA");
		public static SceneID SeinEnergyInfo = new SceneID("4DE917EC7C3072427FEBCC44A35880B9");
		public static SceneID SavePedestals = new SceneID("44C2B52E4830C74C96FEAD2C45332E8D");
		public static SceneID WorldEvents = new SceneID("4744D2581864E35223F834212805F1B0");
		public static SceneID SwimmingBar_Animator = new SceneID("4F040433FBDBFD6AA1C6F26773D49DA4") {
			Children = new List<SceneID>() {
				new SceneID("4605C622E293847940D38CE24219D5AE")
			}
		};
		//SunkenGladesSpiritCavernWalljumpB
		public static SceneID WallJumpTimeLine = new SceneID("4478A1869C0C7012B29B6A2736B8C0A4");
		//GinsoTreeBashRedirectArt
		public static SceneID BashTimeLine = new SceneID("4FDF95A28FD3D3BF10712444684F7A9C");
		//ThornfeltSwampStompAbility
		public static SceneID StompTimeLine = new SceneID("4031519A7406E601E4B59762FD1D18BB");
		//MangroveFallsGetGrenade
		public static SceneID GrenadeTimeLine = new SceneID("4A69E1ACE5783606029C5ECEA59CA793");
		public static SceneID DashTimeLine = new SceneID("47C2445C28B7357A7202B8D8781E7292");

		public static SceneID ForlornRuinsC = new SceneID("BAB44F6981AC324314572CF5F2F7C3E9");
		public static SceneID ForlornRuinsEntrancePlaceholder = new SceneID("1B24B91ADBC5C18DFD4622597D4569EA");
		public static SceneID ForlornRuinsGetIceB = new SceneID("5EE4003A71419EF95A4E442D4F3D926A");
		public static SceneID ForlornRuinsGetNightberry = new SceneID("D6847564EDB0F68B21C1236FD982CD1E");
		public static SceneID ForlornRuinsGravityFreeFall = new SceneID("C4347F734B64B546C5BDB82E23A8B14B");
		public static SceneID ForlornRuinsGravityRoomA = new SceneID("D5A4EC19F961367D1D54D2F5E87BEBD9");
		public static SceneID ForlornRuinsKuroHideStreamlined = new SceneID("D3C48674B812A9B87FE5B1D0D79334FA");
		public static SceneID ForlornRuinsNestC = new SceneID("A4E4AD0E565C55C15C7BEA9D20B02DF8");
		public static SceneID ForlornRuinsResurrectionAfter = new SceneID("6BB948F45E931A709C9E5491CAB035EC");
		public static SceneID GinsoEntranceIntro = new SceneID("D85C37344F883B0B752ECDA449B623F2");
		public static SceneID GinsoEntranceSketch = new SceneID("394F8E3465A2D8100DC225E54BCC12DB");
		public static SceneID GinsoTreeBashRedirectArt = new SceneID("7754B1F3318DD61085C25C9DF9B15C98");
		public static SceneID GinsoTreePuzzles = new SceneID("05F49EE752906E751E99F1FFA221F0BB");
		public static SceneID GinsoTreeRedirectionRoom = new SceneID("E674FB905BBCC6B5A3161EB7762F7C28");
		public static SceneID GinsoTreeResurrection = new SceneID("D7C4DE82DAF25E771D279A42CE604AE8");
		public static SceneID GinsoTreeResurrectionBash = new SceneID("29D408BBF1D396690719DE4B12C8E3DB");
		public static SceneID GinsoTreeSprings = new SceneID("E9240F222C08B57549ADBC4D02DA61F9");
		public static SceneID GinsoTreeTurrets = new SceneID("54B4CB66B28B5525DF77C6CC5768A04B");
		public static SceneID GinsoTreeWaterRisingBtm = new SceneID("C0047B85E9758AEE1B190CBBC8458BE9");
		public static SceneID GinsoTreeWaterRisingEnd = new SceneID("96D48BAA0F0987B6F206F41FBE15D5CB");
		public static SceneID GinsoTreeWaterRisingMid = new SceneID("18949207B4221D7C15211776D578F28B");
		public static SceneID HoruFieldsB = new SceneID("99A44AE399273496E3F872CFD461782A");
		public static SceneID HoruFieldsSlopeTransition = new SceneID("FBA418E1D484EC153EC61BA700A1FD2A");
		public static SceneID MangroveFallsChargeDashIntro = new SceneID("CB1447B00120C01CB6CE6420483A19E8");
		public static SceneID MangroveFallsChargeDashIntroL = new SceneID("3744146CB055A9C7B4F2B543D71306DA");
		public static SceneID MangroveFallsChargeDashIntroR = new SceneID("7194C27DE34FA59EEF1C18C58A43FDA9");
		public static SceneID MangroveFallsDashEscalation = new SceneID("B4F4684AAF716807F8EF86D45429423B");
		public static SceneID MangroveFallsDashIntro = new SceneID("69CB5644B44F5B6519096DD43B13DF8C");
		public static SceneID MangroveFallsGetGrenade = new SceneID("E6C4CA7AC27058F9817E0ADAE21D74B8");
		public static SceneID MangroveFallsGrenadeEscalation = new SceneID("A664AF2E8A8732F391BF3DD32C3ED1F8");
		public static SceneID MangroveFallsGrenadeEscalationR = new SceneID("3084738D7254B9F4425FEE58F86C9F18");
		public static SceneID MistyWoodsCeilingClimbing = new SceneID("5A343558C96892926513A7C593FE5C9B");
		public static SceneID MistyWoodsDocks = new SceneID("CB94B3544B6E75DA67EE43D34B7A0D39");
		public static SceneID MistyWoodsDocksB = new SceneID("CA34C31AE29DC88EC11F24E09F50C25A");
		public static SceneID MistyWoodsGetClimb = new SceneID("CD64DF8FCA0BBB6EC53BF4D2D5DD655A");
		public static SceneID MistyWoodsGetTorch = new SceneID("AF844791A8E493506C012181B2606E4A");
		public static SceneID MistyWoodsGlideMazeA = new SceneID("38243E2FDB4BFF3E356F3759CCBBE1EB");
		public static SceneID MistyWoodsGlideMazeB = new SceneID("5C04F92C5DF1D9B28C6463E9499EA5AB");
		public static SceneID MistyWoodsIntro = new SceneID("DB5422ECDB82FB232676264D5768408B");
		public static SceneID MistyWoodsJumpProjectile = new SceneID("A424BE160496A22DE76A4B55E89E40FA");
		public static SceneID MistyWoodsMortarBash = new SceneID("0EB44D8994421B68C53AFD4554E720FA");
		public static SceneID MistyWoodsNarrowPassage = new SceneID("62D4B952A570FF3AE561D0ACC8DF6FB9");
		public static SceneID MistyWoodsProjectileBashing = new SceneID("B7C46954BDBF20FBBEF639587A166F7A");
		public static SceneID MistyWoodsRopeBridge = new SceneID("8BE43E27C07D90CCFE7C62DA7DA4B4B8");
		public static SceneID MoonGrottoAdvancedDoubleJump = new SceneID("9FA42355BA3986EDADAEB3305E8B0628");
		public static SceneID MoonGrottoBasin = new SceneID("51C4CE1FDA239DBFE3A012C516C5F11B");
		public static SceneID MoonGrottoDoubleJump = new SceneID("6DA4B1335C0B515A75E61445173E0E39");
		public static SceneID MoonGrottoDoubleJumpIntroductionArt = new SceneID("04B42D5B8D2573201358B7AE6F753389");
		public static SceneID MoonGrottoEnemyPuzzle = new SceneID("766445C681B537542659DCB59B2EFA68");
		public static SceneID MoonGrottoGumosHideoutB = new SceneID("E914EAE067AB8440741EB807843E97B9");
		public static SceneID MoonGrottoGumosLastTrap = new SceneID("D3444C5AED0640B3F89159DA2584538A");
		public static SceneID MoonGrottoHubSplitA = new SceneID("68441C64244D766E9BF6A8145244586A");
		public static SceneID MoonGrottoHubSplitB = new SceneID("F0044ED69426324A1A4C4952297DA809");
		public static SceneID MoonGrottoHubSplitC = new SceneID("86248064E599641627C23ECC61AA2A49");
		public static SceneID MoonGrottoLaserIntroduction = new SceneID("F78404F572FAF42C9198B4761493FE88");
		public static SceneID MoonGrottoLaserPuzzle = new SceneID("65044E379D829D0C574638C83503FFBB");
		public static SceneID MoonGrottoLaserPuzzleB = new SceneID("56442CD5F4F32938B08ABCD33E9E4B3B");
		public static SceneID MoonGrottoMovingPlatformSideways = new SceneID("55F4415B646B1D4F6C2A02FD69D0BF28");
		public static SceneID MoonGrottoMovingPlatformVertical = new SceneID("4F04DEAA2E40233CEE1F99BC8EB366F8");
		public static SceneID MoonGrottoRopeBridge = new SceneID("4D04125ABDFE52935D5EED4D6EEB127B");
		public static SceneID MoonGrottoSecretAreaA = new SceneID("96546E92AE6EC7E6E7D31EB30E364A58");
		public static SceneID MoonGrottoShortcutA = new SceneID("60FA29F4E7A25B191F3CF3B869129EE0");
		public static SceneID MoonGrottoStomperIntroduction = new SceneID("CDE4A5DE03D09F3C2E5B148DB543CDEB");
		public static SceneID MountHoruBackgroundA = new SceneID("D774F1A067C16E9C00A802B686DE80BA");
		public static SceneID MountHoruBigPushBlock = new SceneID("5024A7B0F6794BD42E42EBAEBCC029AB");
		public static SceneID MountHoruBreakyPathBtm = new SceneID("3C8465CA5074EE0FF9E77CBA40F9257B");
		public static SceneID MountHoruBreakyPathTop = new SceneID("A66403633A07D1EDD56948B30B2CBF3B");
		public static SceneID MountHoruHubBottom = new SceneID("61E45F6F47D46853C674DBA1205DC0D8");
		public static SceneID MountHoruHubMid = new SceneID("B3243ABE45FD45E3F71233F7FEC2EC3A");
		public static SceneID MountHoruHubTop = new SceneID("18D481E8655EC7FDFCE74849EACC614B");
		public static SceneID MountHoruLaserPuzzle = new SceneID("6B74EDD285E87A6A85C8CC93BBC65569");
		public static SceneID MountHoruLaserTurretsR = new SceneID("E774AB52B51081453CA6891D50680D39");
		public static SceneID MountHoruMovingLaser = new SceneID("99542A0A4B7E4819737C2276C536CC88");
		public static SceneID MountHoruMovingPlatform = new SceneID("41F44FD7613B77F5F71CA8454D1222CB");
		public static SceneID MountHoruStomperSystemsL = new SceneID("C2043BE3D8D7CC72CA4D1080BEFE49E8");
		public static SceneID MountHoruStomperSystemsR = new SceneID("CD44813D912453D39997A4FEFFCBA53A");
		public static SceneID NorthMangroveFallsGetDash = new SceneID("D914E0B7F0F030F1D422BB9A2C3138FA");
		public static SceneID NorthMangroveFallsIntro = new SceneID("5E69BDB4F5A5301E006007BFCBDDEE55");
		public static SceneID NorthMangroveFallsLanternIntro = new SceneID("0A5028948B90345BDB22AE93295DD576");
		public static SceneID SorrowPassEntranceA = new SceneID("8C14D0884ADE21B7582605B8767A492B");
		public static SceneID SorrowPassEntranceB = new SceneID("E1643C512FDC746081BA78DFB773C7CA");
		public static SceneID SorrowPassForestB = new SceneID("72446692E076F364F27A579A86CD58CA");
		public static SceneID SorrowPassValleyD = new SceneID("FE14AED239811A9DBF328C4CDF557CC8");
		public static SceneID SouthMangroveFallsGrenadeEscalationBR = new SceneID("FF843D6A7120827403C5B8A5ACCB076B");
		public static SceneID SouthMangroveFallsStoryRoomA = new SceneID("3614A8A4F4ED6BBA817824987B8ABE60");
		public static SceneID SpiritTreeRefined = new SceneID("C7446908045D4CAA22D8176DD2C2203B");
		public static SceneID SunkenGladesBackgroundB = new SceneID("E8346DDE7C5797FC712CE0C018E91CCB");
		public static SceneID SunkenGladesEnemyIntroductionC = new SceneID("A90483B9719C75E875E7EE833E7F5688");
		public static SceneID SunkenGladesIntroSplitA = new SceneID("FD940220E460F5F9FFBE19CE2985B628");
		public static SceneID SunkenGladesIntroSplitB = new SceneID("47E4D2DD460CBF8B05F44FD77932CE28");
		public static SceneID SunkenGladesObstaclesIntroductionStreamlined = new SceneID("C634DBF9C8BDF2A5FB8C4B79D9E8BD9B");
		public static SceneID SunkenGladesOriRoom = new SceneID("D09420BE69EF1B07BE1A61C7DFEFD9D8");
		public static SceneID SunkenGladesRunaway = new SceneID("5324FBF48F2DDD5D9C1569E8F9F53778");
		public static SceneID SunkenGladesRunning = new SceneID("55A4D835D57D56A1A19BE4202A6AE188");
		public static SceneID SunkenGladesSpiritCavernB = new SceneID("3554C8818518FCAE023CD088475E4A09");
		public static SceneID SunkenGladesSpiritCavernLaser = new SceneID("A1C4F459608976805256ACC162ADACE9");
		public static SceneID SunkenGladesSpiritCavernSaveRoomB = new SceneID("4AA4B0065F6B5F0DE686413C563FD669");
		public static SceneID SunkenGladesSpiritCavernsPushBlockIntroduction = new SceneID("2BB401CB8B4711EA7C3DDB945345CAEB");
		public static SceneID SunkenGladesSpiritCavernWalljumpB = new SceneID("7CA4DB8588A8922F361015A018512F59");
		public static SceneID SunkenGladesWaterhole = new SceneID("F0C48189EF9E26256B26ED4BEF33227A");
		public static SceneID ThornfeltSwampA = new SceneID("D4F4F0D18F3B15311394313E7C9705C8");
		public static SceneID ThornfeltSwampActTwoStart = new SceneID("28948743B329250A6718A34E214E6B7A");
		public static SceneID ThornfeltSwampB = new SceneID("D7644B150C86E34C89F696C766B4C7CA");
		public static SceneID ThornfeltSwampBackgroundA = new SceneID("93A409B80878F0072AF0FBA699A48D59");
		public static SceneID ThornfeltSwampE = new SceneID("56844F81A45C5468A3C9A1FD8A6C6169");
		public static SceneID ThornfeltSwampMoonGrottoTransition = new SceneID("FBA4E276E0FB795087FE2C69CB4ED4C9");
		public static SceneID ThornfeltSwampStompAbility = new SceneID("88348ACCB3314FE547361F3090484469");
		public static SceneID UpperGladesBelowSpiritTree = new SceneID("55540DDC562300008DB1214F19323B08");
		public static SceneID UpperGladesHollowTreeSplitA = new SceneID("09DB8E94E976B0B76571683A6924B836");
		public static SceneID UpperGladesHollowTreeSplitB = new SceneID("5AAB88B4435E617FD22084BC2980C5A5");
		public static SceneID UpperGladesHollowTreeSplitC = new SceneID("54F979D43C2166E052C31F5E6A034321");
		public static SceneID UpperGladesSpiderCavernPuzzle = new SceneID("1D7B6D64A481E8305CECFE5668F4B14E");
		public static SceneID UpperGladesSpiderIntroduction = new SceneID("B80411B17573A33ADB33A6C90FA50E1A");
		public static SceneID UpperGladesSpiderIntroductionB = new SceneID("4B6A403496A35B4438B140C1F831DC8E");
		public static SceneID UpperGladesSwampCliffs = new SceneID("5324F0252D5BE3A774ABE774022D582A");
		public static SceneID UpperGladesSwarmIntroduction = new SceneID("3CCBFEA4BCE6367553B30E401B80F28F");
		public static SceneID ValleyOfTheWindBackground = new SceneID("98346D449154866ADF7304DE5F0A2289");
		public static SceneID ValleyOfTheWindEArt = new SceneID("43F41FCB15576D9CF3C404BAB46829FA");
		public static SceneID ValleyOfTheWindGauntlet = new SceneID("A9644D2B2FDFD64BA7DFC04CBF779B3A");
		public static SceneID ValleyOfTheWindGetChargeJump = new SceneID("94E474A7E4F9426DABE8C51F132DEEC9");
		public static SceneID ValleyOfTheWindHubIceLaserB = new SceneID("2C742CCB8883D1DDC877A728FA8AC20B");
		public static SceneID ValleyOfTheWindHubL = new SceneID("AA44F447B2167F26653C2D14300B0269");
		public static SceneID ValleyOfTheWindHubR = new SceneID("A194AF97E5F553251D17D3AB3A0B1659");
		public static SceneID ValleyOfTheWindIcePuzzle = new SceneID("DA749E1E6849A2AE99EB820A4703F259");
		public static SceneID ValleyOfTheWindLaserShaft = new SceneID("02140A21B8034AE7785E686589BF275B");
		public static SceneID ValleyOfTheWindShaft = new SceneID("48E4B5F7DEAE4941DF28ABBDF8E52039");
		public static SceneID ValleyOfTheWindTop = new SceneID("6894BA82F7977493690FF50D121FCD4A");
		public static SceneID ValleyOfTheWindWideLeft = new SceneID("AEB425F14774E9A752A40445F44B8718");
		public static SceneID ValleyOfTheWindWideMid = new SceneID("1FC408540F6DCC4C5DC1AEE1E101659B");
		public static SceneID ValleyOfTheWindWideRight = new SceneID("F114516EED179E7BABF6E49E38404A28");
		public static SceneID WestGladesBashCave = new SceneID("5864E434CE0DC42B0306E2B619D94AB5");
		public static SceneID WestGladesCliffsC = new SceneID("422AF1743F939EE3FFF4C8A14830162E");
		public static SceneID WestGladesFireflyAreaA = new SceneID("0565A3F4CB45342E9A13F3340A532932");
		public static SceneID WestGladesOverworldForestA = new SceneID("01C05B94E20113F6DB05861438183127");
		public static SceneID WestGladesRollingSootIntroduction = new SceneID("06448447607CEAA28132B43E697E5B1B");
		public static SceneID WestGladesSorrowEntranceAB = new SceneID("0838EC941BECFE1C9F806955284E9240");
		public static SceneID WestGladesTIntersectionB = new SceneID("73EAED544D85B5A7F8E061525BE9E839");
		public static SceneID WestGladesWaterStomp = new SceneID("A72A1CD4ABDF2394D05204B27A765B82");
	}
	public class ForlornRuinsC : SceneID {
		public static SceneID ForlornEntranceLoad_Trigger = new SceneID("49CA7F2BCA63972289AE3812EB8F779C");
		public static SceneID DoorWithFourSlots = new SceneID("4925946AF209489A5D441DDF3C647CAC");
	}
	public class ForlornRuinsEntrancePlaceholder : SceneID {
		public static SceneID SpiritTreeTexts_TextA_Trigger = new SceneID("4BDE286A8F25AF02F03FE3EB8D25C2BF");
		public static SceneID SpiritTreeTexts_TextB_Trigger = new SceneID("4DCB6739D71303C9A3B35EF86CAA39AC");
	}
	public class ForlornRuinsGetIceB : SceneID {
		public static SceneID HealthCell = new SceneID("4DEEB8264C8C35A8C3940F6239C770AD");
		public static SceneID PetrifiedPlant = new SceneID("46CFDE5728226424D744D72E18D6538F");
	}
	public class ForlornRuinsGetNightberry : SceneID {
		public static SceneID StorySetups_StoryTextWithTrigger_Trigger = new SceneID("4A3914A06F015E2EA8953EA7A0375289");
		public static SceneID Hintzones_DeactivateLightVesselHint_Trigger = new SceneID("46230DAFB5B50D37FC5CB31FDDBBDBB6");
		public static SceneID ExpOrb200 = new SceneID("422BD4A45103CD695F0B2372E790278F");
	}
	public class ForlornRuinsGravityFreeFall : SceneID {
		public static SceneID Keystone1 = new SceneID("4F9984C339CA806CB4279AF6EAA79EAF");
		public static SceneID PetrifiedPlant = new SceneID("409DB75238FFFF94AAB8CAFDA5CB4286");
		public static SceneID Keystone2 = new SceneID("41FB9179EFCE9B2E1D5E62DA5FC69080");
	}
	public class ForlornRuinsGravityRoomA : SceneID {
		public static SceneID Keystone1 = new SceneID("42CC7520DDE720340EF3AEC06AE257A4");
		public static SceneID ExpOrb100 = new SceneID("4BE242B9808F0342D2C83B88A563D580");
		public static SceneID Keystone2 = new SceneID("42F2AEBFFBF8A28FFE396B9B466907AC");
	}
	public class ForlornRuinsKuroHideStreamlined : SceneID {
		public static SceneID SunkenGladesStompTree = new SceneID("436082B8CDA3ED5169D21DAAB5C72B9A");
		public static SceneID BombableWall = new SceneID("41696C1DF3FDBFC7F9211C099E0039B4");
		public static SceneID ChargeFlameWall = new SceneID("47B1ED4D626FCDF1227771427A42F2AE");
		public static SceneID ExpOrb200_1 = new SceneID("4A652583B7F86A8551497A91A09B2086");
		public static SceneID ExpOrb200_2 = new SceneID("415F83E4999D6909EDE7244A3A3DB0B3");
		public static SceneID ExpOrb100 = new SceneID("40FCE23CB081638DD1A305FA6AB94C95");
		public static SceneID StompablePlatform_LeftRight = new SceneID("42EA38D435FC9E690350BE3FC0C495AF");
		public static SceneID StompablePlatform_RightLeft = new SceneID("476B8167C18EFFDE3998A40153B3AB99");
		public static SceneID StompablePlatform_RightRight = new SceneID("462F75B802F4F5F84E34712297419ABF");
	}
	public class ForlornRuinsNestC : SceneID {
		public static SceneID StoryNew_Exit_Trigger = new SceneID("4817798B3C9B337DB252A1A7B38B81BA");
		public static SceneID StoryNew_Setup_Collider_Trigger = new SceneID("4A4CE62919B6FF272F79EA4120A13FB0");
		public static SceneID AreaTextZone_Trigger = new SceneID("46BD152CB330899BAAFE1209F29A679F");
		public static SceneID PetrifiedPlant = new SceneID("4E975F62388CA787F2BE51C55F3F4A8C");
		public static SceneID RideTheWind_Trigger = new SceneID("445BE1F5BDFDF37C7D89BA88C698ED85");
	}
	public class ForlornRuinsResurrectionAfter : SceneID {
		public static SceneID Resurrection_Trigger = new SceneID("4E08139FF5C7DEA8000666CE37873686");
		public static SceneID HintZones_DeactivateJumpHigherHint_Trigger = new SceneID("4F1D615227D4B87D8F9998AEE68839BB");
		public static SceneID RideTheWind_Trigger = new SceneID("4F9D7B3354DBD1B6443CD87BDD1640B3");
	}
	public class GinsoEntranceIntro : SceneID {
		public static SceneID PetrifiedPlant = new SceneID("4473678075BC23B083C0368AB62AEB99");
		public static SceneID Creep1 = new SceneID("42559C2A3BA27850A9861FCF4E949A8C");
		public static SceneID Creep2 = new SceneID("42B70A7770B3186F0ABF8C4C97043EA0");
		public static SceneID Creep3 = new SceneID("4B8E52F083D2CC80975AD381AEBEF783");
		public static SceneID Creep4 = new SceneID("46A826F4D26098AE37F9D4B17C0247AD");
	}
	public class GinsoEntranceSketch : SceneID {
		public static SceneID Setups_StealingSetup_Trigger = new SceneID("48D6FFDCF202C98F2D6E4745A6384284");
		public static SceneID SpiritTreeTexts_TextA_Trigger = new SceneID("4E011F9A69F2B21607D53F9E25E972AB");
		public static SceneID SpiritTreeTexts_TextB_Trigger = new SceneID("4824465F74190A8E8B3CE21C9798EDB7");
	}
	public class GinsoTreeBashRedirectArt : SceneID {
		public static SceneID BombableWall1 = new SceneID("4D3F712462F7CDFF5952D5BB94CF5EBE");
		public static SceneID BombableWall2 = new SceneID("4B7C58B3689FD9FCF5B958FA496148AD");
		public static SceneID BombableWall3 = new SceneID("4F7AE7B66A19C7DF3468BFC48E26AA87");
		public static SceneID BombableWall4 = new SceneID("49D1DEF2194F03C3F0F6A750E9C68EB0");
		public static SceneID BombableWall5 = new SceneID("42C00D65FFF7854CABDC4546F78BD1BD");
		public static SceneID EnergyCell = new SceneID("4D252EFAEB89657CED8038299A7CB5BD");
		public static SceneID ExpOrb100_1 = new SceneID("452CFDC0BAD697635EE0AE16E30A3AB2");
		public static SceneID ExpOrb100_2 = new SceneID("491551CD28351EBFDAEEB37519A835A3");
		public static SceneID ExpOrb100_3 = new SceneID("40F4E837D42F58B552D55B1265E76B96");
	}
	public class GinsoTreePuzzles : SceneID {
		public static SceneID Keystone1 = new SceneID("413B531DA210AA8A5B0EDF005AD1E3B6");
		public static SceneID Keystone2 = new SceneID("4EFFA099943EA4A8965BE90950116BA3");
		public static SceneID Keystone3 = new SceneID("4CC308828A0BB6E04A8C509AEFFEAA9C");
		public static SceneID Keystone4 = new SceneID("4BC431863AEF4A7C5AF455DADAF570B6");
		public static SceneID DoorWithFourSlots = new SceneID("4ED1FDE8168C74A2A12F47CC0E73D499");
		public static SceneID BombableWall1 = new SceneID("4514992A897C95390D8B6B7D8336A1BB");
		public static SceneID BombableWall2 = new SceneID("451ED60FDF644CC41B717905FEDC158A");
	}
	public class GinsoTreeRedirectionRoom : SceneID {
		public static SceneID BombableWall = new SceneID("4EA7D5C81106F803C5CEC62A70CCC3BC");
		public static SceneID PetrifiedPlant = new SceneID("4FBD122D4561990F1B9F0C5AEAF1F68A");
	}
	public class GinsoTreeResurrection : SceneID {
		public static SceneID HeartLeft_Main_Creep = new SceneID("415E94C865B203B5646D50DB5CF39190");
		public static SceneID HeartLeft_CreepA = new SceneID("4D7C5B4873412306E9FE9EC6E7DEE49B");
		public static SceneID HeartLeft_CreepB = new SceneID("49160F03EFE7C1C86B8291B7F73F36BA");
		public static SceneID HeartLeft_CreepC = new SceneID("46C489DB36A0EBF0CC24AB825F020485");
		public static SceneID HeartLeft_CreepD = new SceneID("44D916057109C4ACBBF55AD8E872758B");
		public static SceneID HeartLeft_CreepE = new SceneID("423421106F98DE2D9D89045179EFFC85");
		public static SceneID HeartLeft_CreepF = new SceneID("4CF8D9CAE599BF77D97B330AB26D068B");
		public static SceneID HeartLeft_CreepG = new SceneID("499EE09EA02C93B4F3C551D9E15DD7A1");
		public static SceneID HeartLeft_CreepH = new SceneID("4170E2113B54AAAA1C66D75FFABD6888");
		public static SceneID HeartLeft_CreepI = new SceneID("43473B0A0FCD9908BD0CB1A02E1A7084");
		public static SceneID HeartLeft_CreepJ = new SceneID("4684AA80381F6A0CA85CC7FFEE788C85");
		public static SceneID HeartLeft_CreepK = new SceneID("4D07798F813DC6D3CF32C777DFC074AB");
		public static SceneID HeartRight_Main_Creep = new SceneID("4E8CD4C676C3B8B526BDE8365020DBA8");
		public static SceneID HeartRight_CreepA = new SceneID("49BE3E6EC693B68DA7337CA6D9D2AA97");
		public static SceneID HeartRight_CreepB = new SceneID("407CB9F0C2E1AF3BBE88F45228037EAD");
		public static SceneID HeartRight_CreepC = new SceneID("4BE6717D9B7D331FA6858153322B899C");
		public static SceneID HeartRight_CreepD = new SceneID("4C7566BFA130A8A6D81F42C995FC5CBC");
		public static SceneID HeartRight_CreepE = new SceneID("4A73B6E84BC9FF3FDB4BD5B521548396");
		public static SceneID HeartRight_CreepF = new SceneID("45EBC4B85161CB74445D1A54C5FBEE99");
		public static SceneID HeartRight_CreepG = new SceneID("4DFC3DE61FB02B369A595FDA9577599F");
		public static SceneID HeartRight_CreepH = new SceneID("4DB6CF55A1E3046E59063E7B5BB332A0");
		public static SceneID HeartRight_CreepI = new SceneID("48713DF20E1A2178072F2A3BF5985E86");
		public static SceneID HeartRight_CreepJ = new SceneID("49B71B668C765F1A01AA540A77F063AE");
		public static SceneID HeartRight_CreepK = new SceneID("4FE8C81DA31B73D3F7C85E590E5C089F");
		public static SceneID HeartRight_CreepL = new SceneID("4655F6DB7E924FD6CF85359B0B177F9A");
	}
	public class GinsoTreeResurrectionBash : SceneID {
		public static SceneID Keystone1 = new SceneID("449C108DB8FD25735DD12AE101F21DA3");
		public static SceneID Keystone2 = new SceneID("4890112F51D877F6B917582BAB92EBAB");
		public static SceneID Keystone3 = new SceneID("43A0F8AC902CB43A89D633967B0CA1AB");
		public static SceneID Keystone4 = new SceneID("417548717399CD964F46E02780D0CEAD");
		public static SceneID DoorWithFourSlots = new SceneID("4B05BC416FB2EAA9815270CECA38A0BD");
	}
	public class GinsoTreeSprings : SceneID {
		public static SceneID Creep1 = new SceneID("4208C6BF6206A07567D3B41A4272B381");
		public static SceneID Creep2 = new SceneID("43FE0642EA2919C1BF49CB3977B5BA89");
		public static SceneID Creep3 = new SceneID("4B6E4923DA4E9124AF1A0C170E4730A5");
		public static SceneID Creep4 = new SceneID("44FF413C31E372986C44BA569FB3BBBF");
		public static SceneID ExpOrb100 = new SceneID("473C81996B0C9DC244ACF4B1C8E50581");
	}
	public class GinsoTreeTurrets : SceneID {
		public static SceneID BombableWall = new SceneID("462B9C2959EED2CEE6907E45FFB915AB");
		public static SceneID ExpOrb100_1 = new SceneID("422B7C323BCA40F32F89BB7B32DF3C9F");
		public static SceneID ExpOrb100_2 = new SceneID("43704C8F54CAC8A1AEA044FDD98A2B86");
	}
	public class GinsoTreeWaterRisingBtm : SceneID {
		public static SceneID ExpOrb200 = new SceneID("4291216C8DCEB0F4826E98F931D74DB4");
	}
	public class GinsoTreeWaterRisingEnd : SceneID {
		public static SceneID ExpOrb100 = new SceneID("4A832259F27009A310D080EBF4B90E86");
	}
	public class GinsoTreeWaterRisingMid : SceneID {
		public static SceneID ExpOrb100_1 = new SceneID("4CC8525FC425D212CC7109B613FC0AB7");
		public static SceneID ExpOrb100_2 = new SceneID("4AFB480E03376DA181EE3F1418C390B7");
	}
	public class HoruFieldsB : SceneID {
		public static SceneID ExpOrb200 = new SceneID("46C44D7AE1F621547B716C290891598C");
		public static SceneID PetrifiedPlant = new SceneID("4D7750BD37E00EA33DE87E3D6B3E9280");
	}
	public class HoruFieldsSlopeTransition : SceneID {
		public static SceneID Wall1 = new SceneID("402C8B2FA2EDAB3358B15683E8A90499");
		public static SceneID Wall2 = new SceneID("4D635D50F3297093E083E65EAAF4F8B7");
		public static SceneID EnergyCell = new SceneID("498B9209996C91FC4ADB73B8C6390EA7");
		public static SceneID AbilityCell = new SceneID("4CDFD14A7D9BFBB23B1D790A283A8D9C");
		public static SceneID StompableFloor = new SceneID("4AC991B610F77CC994CA6B0E5740C0B1");
	}
	public class MangroveFallsChargeDashIntro : SceneID {
		public static SceneID AbilityCell = new SceneID("45AFE3369BF62AC3304958BF7C96918E");
	}
	public class MangroveFallsChargeDashIntroL : SceneID {
		public static SceneID NaruStorySetupB_Trigger = new SceneID("4AD3C463B39B2936C12982567190F1B8");
		public static SceneID NaruStorySetupB_DeactivateRestrictZones = new SceneID("4E8852CD64408C3E4FE0D2BDAD1E66AD");
		public static SceneID SpiritTorch = new SceneID("4A4E7677690F1017CDBF24A4C87FCE86") {
			Children = new List<SceneID>() { new SceneID("4DA616708722C547FA4A851A531207A7") { Name = "Animator" },
											 new SceneID("445CD56056F5B60DE1138552C2E7E4A2") { Name = "Activator" },
											 new SceneID("47809624D56E51D87DAA0CA3868AD493"),
											 new SceneID("44F54129683D3E84FD9CFAA686DEC29A") { Name = "Deactivate" } }
		};
	}
	public class MangroveFallsChargeDashIntroR : SceneID {
		public static SceneID ExpOrb100 = new SceneID("4B903DE1983B2612F826AC3E71F528B3");
		public static SceneID Creep = new SceneID("4BC4081426FAE1F86838184DB7250792");
		public static SceneID SpiritTorch = new SceneID("495D0B9C160AEF2AFB4865708F611696") {
			Children = new List<SceneID>() { new SceneID("474ABE51334B21884C7275F79AA88881") { Name = "Animator" },
											 new SceneID("47B8ACE6DB107BD1BCD05265C1D439BB") { Name = "Activator" },
											 new SceneID("4A9D8ADDDE12A92E2B5F5D253C39528A") }
		};
	}
	public class MangroveFallsDashEscalation : SceneID {
		public static SceneID BoulderSetup_BoulderStompableAfterChase_Trigger = new SceneID("4EBD0CA60B9D6214E61F2670B8A0608F");
		public static SceneID BoulderSetup_ByDifficulty_Trigger = new SceneID("4914D157876CF4B5BC182023941E6BA1");
		public static SceneID HealthCell = new SceneID("4EC1E56110D4CD81D0395D5C60530084");
		public static SceneID ExpOrb100 = new SceneID("4EDC3F1EF777E08165315C97FD041EA3");
	}
	public class MangroveFallsDashIntro : SceneID {
		public static SceneID ExpOrb100 = new SceneID("4E68335EBD4B5CAE05EE0A0F25BF6199");
		public static SceneID AbilityCell = new SceneID("46DD6B7CA7F42011CF16AD14A66BCCA8");
		public static SceneID StompableFloor = new SceneID("4219973BF3D98BEDCF9B0119FF86DCA2");
	}
	public class MangroveFallsGetGrenade : SceneID {
		public static SceneID PlatformOnRopeEfficient_Trigger = new SceneID("40FB94911E8415BBB0204902ED96B7AC");
		public static SceneID ObjectiveSetup_Trigger = new SceneID("4BB7A220821C5A23413E05083BB4739A");
		public static SceneID SpiritTorchLeft = new SceneID("4622C811A878CEAD1FD2C31C53BAABAA") {
			Children = new List<SceneID>() { new SceneID("458EE6D9BB129E23F800DA060C35689A") { Name = "Animator" },
											 new SceneID("453F12FE28DC666F14CE64885BAE948D") }
		};
		public static SceneID SpiritTorchRight = new SceneID("4265A675B87CACAE095674E8803D6DBC") {
			Children = new List<SceneID>() { new SceneID("4C9F71A8CA5CD5544FBCDBB9A13309A2") { Name = "Animator" },
											 new SceneID("43D22019F4514232809ED10FE043BBA1") { Name = "Activator" },
											 new SceneID("476803236D49E36ED99578F83115A1A6") }
		};
	}
	public class MangroveFallsGrenadeEscalation : SceneID {
		public static SceneID BlockPlayer_activateCollider_Trigger = new SceneID("4F0E415EC46F0494E0EECF9A9C9195A4");
		public static SceneID BlockPlayer_deactivateCollider_Trigger = new SceneID("4C13896BF3B0AB820F9C1B6C44DF61A9");
		public static SceneID NaruStorySetupB_Trigger = new SceneID("4ADB257B86AFA111965E1294BD2B3DA3");
		public static SceneID Creep1 = new SceneID("430AECEF4F270D480AE5BF6FE5EC75B8");
		public static SceneID Creep2 = new SceneID("480CAEC88AE893A838F54D779D9D40B1");
		public static SceneID Creep3 = new SceneID("4B1272E92186E96279971A4384613F9C");
		public static SceneID Creep4 = new SceneID("49C2E7222F34CD678F9C66C72423BCAA");
		public static SceneID Creep5 = new SceneID("4D80E21C3120BBF14D1734281C82E3A2");
		public static SceneID AbilityCell = new SceneID("404DCACB5B373D3EEED67B85BC1C899C");
		public static SceneID SpiritTorch = new SceneID("40EE167248A244819889EBD67D47FA90") {
			Children = new List<SceneID>() { new SceneID("4830ADF437255ED9A92483DFDF6A6680") { Name = "Animator" },
											 new SceneID("4ED662F0BF8780B7B53BAE36ADE346B3") { Name = "Activator" },
											 new SceneID("4E1EFDA98E5BDC58F0ECFC95FFD9DBA9") }
		};
	}
	public class MangroveFallsGrenadeEscalationR : SceneID {
		public static SceneID ExpOrb100 = new SceneID("48DAAB8E48E39D5EF1C2A0F5E7874382");
		public static SceneID AbilityCell = new SceneID("4FE7D425F40AE03F1A9EBCCDB548E6B1");
		public static SceneID FightRoomDoor_Animator = new SceneID("4F4A648B33B530658E0278EF3678A2BF");
		public static SceneID SpiritTorch = new SceneID("454C4BC731FD5BB75DB5C8596BD5F8A0") {
			Children = new List<SceneID>() { new SceneID("45239B746C82E6629E9C8DCBE24AB388") { Name = "Animator" },
											 new SceneID("49B546D4743E5024B5EE206EF76371B2") { Name = "Activator" },
											 new SceneID("490E03EB3D5ED802815270B98D398882") }
		};
	}
	public class MistyWoodsCeilingClimbing : SceneID {
		public static SceneID Keystone = new SceneID("4642E0EA40FFFB0261A6D3BCB29C4FB4");
	}
	public class MistyWoodsDocks : SceneID {
		public static SceneID SpiritTorch = new SceneID("419A299D7FD16DD1DF90609B6D8939A6") {
			Children = new List<SceneID>() { new SceneID("4E50F025A7FF80132A472D715208FF84") { Name = "Animator" },
											 new SceneID("4E36760CD297214EB68E9C1177FA37B4") { Name = "Activator" },
											 new SceneID("41FF7D2BD4ADAB7C3D5B707B89D67E8F") }
		};
	}
	public class MistyWoodsDocksB : SceneID {
		public static SceneID Keystone = new SceneID("458A35FED26F356DBD946E9591FD918D");
		public static SceneID AbilityCell = new SceneID("4BE43B39ADCBD988ABD53D3F829CE083");
		public static SceneID SpiritTreeText_Trigger = new SceneID("496C54C1A781CB9F1A0F0187D8008FA3");
	}
	public class MistyWoodsGetClimb : SceneID {
		public static SceneID PetrifiedPlant = new SceneID("4CA4CE3B5D02CA56FDD6BBB4715E7DB5");
		public static SceneID StompableFloor = new SceneID("40ABA3364D5BA10FE2D979B2ABCED8B7");
	}
	public class MistyWoodsGetTorch : SceneID {
		public static SceneID Keystone = new SceneID("4EA8EAD2A8C8BE37C18AD82448E31E8C");
	}
	public class MistyWoodsGlideMazeA : SceneID {
		public static SceneID ExpOrb100_1 = new SceneID("45E178224F8DA24F952A08AB057D7BB9");
		public static SceneID ExpOrb100_2 = new SceneID("45AA93CD1A139E6E2D1CB802B720D0A8");
	}
	public class MistyWoodsGlideMazeB : SceneID {
		public static SceneID ExpOrb100 = new SceneID("4B08052A559229D13DCA6B60B9B60883");
	}
	public class MistyWoodsIntro : SceneID {
		public static SceneID ExpOrb100 = new SceneID("44DAF4B2C75F132F8CA937FFE631CB9A");
	}
	public class MistyWoodsJumpProjectile : SceneID {
		public static SceneID ExpOrb100 = new SceneID("454720C9D51CEABEF0D39A73BCFDFCBC");
	}
	public class MistyWoodsMortarBash : SceneID {
		public static SceneID ExpOrb200 = new SceneID("4EA0A5E2C507A8AEA00D7EA8038E2EBC");
		public static SceneID Keystone = new SceneID("4DE185C57F038640DA0DDE5A8BCF1981");
	}
	public class MistyWoodsNarrowPassage : SceneID {
		public static SceneID RedBulb = new SceneID("44669B4647732F33EC18E0B14053E788");
	}
	public class MistyWoodsProjectileBashing : SceneID {
		public static SceneID ExpOrb200 = new SceneID("4F93D6D860C2CA911C0DFF4B755ABCAF");
	}
	public class MistyWoodsRopeBridge : SceneID {
		public static SceneID DeactivateFallenTree_Trigger = new SceneID("4BCA04E8A32B76022331F4584D1096B4");
		public static SceneID StorySetups_StoryText_Trigger = new SceneID("4A7C7F037FA26D91B505BE7F19742F84");
		public static SceneID WorldEvent_Trigger = new SceneID("43B60983A6E0C67DD49B3008C06F5F8F");
		public static SceneID DoorWithFourSlots = new SceneID("48300EB759F7B52FBDD158B9E9968689");
		public static SceneID RedBulb = new SceneID("40021EEED7D5E42128E45B308C51FB83");
	}
	public class MoonGrottoAdvancedDoubleJump : SceneID {
		public static SceneID GumoAnimationCeilingCrawl_Trigger = new SceneID("4111732C5C813D4E299415277C0F2AAC");
		public static SceneID ExpOrb100 = new SceneID("44E8C59838D57BC4FA06865677163D92");
	}
	public class MoonGrottoBasin : SceneID {
		public static SceneID Creep1 = new SceneID("47257DCAAA96768ABEF0738D2F3D09A3");
		public static SceneID Creep2 = new SceneID("46D481879DB56E81652EA47F566E9086");
		public static SceneID Creep3 = new SceneID("4DA987480FAFD318208762085B3DF582");
		public static SceneID Creep4 = new SceneID("4A504EE30477F19BF96405B932C26E88");
		public static SceneID Creep5 = new SceneID("41E5E281B4B1AB15BB2481C3CFCF668E");
		public static SceneID Creep6 = new SceneID("45C6ADA7AAAE0A67CD9BE57258702B85");
		public static SceneID HealthCell = new SceneID("4352562324172A1DA8B49C1824A52786");
		public static SceneID ExpOrb100_1 = new SceneID("443A2BC6B07B8474EF2FAFC78B1896A3");
		public static SceneID ExpOrb100_2 = new SceneID("42A14BE9DC2119F1FDF16B2F0C14EABC");
	}
	public class MoonGrottoDoubleJump : SceneID {
		public static SceneID HintZones_DeactivateHintZone_Trigger = new SceneID("484D91445D3AE0E3D0DB33114EDC5ABC");
		public static SceneID ExpOrb100 = new SceneID("46A6457C540E52B42F3A1201CD744B90");
	}
	public class MoonGrottoDoubleJumpIntroductionArt : SceneID {
		public static SceneID Setup_Group_Trigger = new SceneID("40EF0E07F040C2A44D5DA3BEFE0FCAA8");
		public static SceneID Creep1 = new SceneID("4F5FD1E83EE839270417B3C3BACE6EA0");
		public static SceneID Creep2 = new SceneID("42A8D59B63E7C95A4F8A42D6C2C19D86");
		public static SceneID Creep3 = new SceneID("4EAC16C58DE4CC6CA1F64EC69B63C9AB");
		public static SceneID Creep4 = new SceneID("4EB12716D3B628EE26123FA0696FC1AA");
		public static SceneID Creep5 = new SceneID("437BF089474C01D7890CEC5C5EB2509A");
		public static SceneID Creep6 = new SceneID("4B675C1F6131E3012D105204833A6696");
	}
	public class MoonGrottoEnemyPuzzle : SceneID {
		public static SceneID GumoAnimationSummonEnemy_Door_Trigger = new SceneID("4BD1C7D0526136511F3C1DB0ED72AA91");
		public static SceneID Keystone = new SceneID("4A00442F217F72CFD20EDF223B784885");
	}
	public class MoonGrottoGumosHideoutB : SceneID {
		public static SceneID GumoAnimationFollowSein_Trigger = new SceneID("4FDA3CCEF01A71211113F553F15F2DAD");
		public static SceneID GumoAnimationJumpEscape_Trigger = new SceneID("495838C6ABF25F7217F3873A2E6C34B9");
		public static SceneID LandSetup_Trigger = new SceneID("41F96D0B0E18BF971B677028F8E4C68B");
		public static SceneID ExpOrb15_1 = new SceneID("44C8F904765F3FC9BA230FD5D5897BB3");
		public static SceneID PetrifiedPlant1 = new SceneID("4B97E869D64072BEE8ECB92231DB9086");
		public static SceneID PetrifiedPlant2 = new SceneID("40EE2C2E32074C9E213D14CB8F56838C");
		public static SceneID ExpOrb15_2 = new SceneID("4E9F3FF37AE703974E6F28F41418E0A3");
	}
	public class MoonGrottoGumosLastTrap : SceneID {
		public static SceneID SavingGumoSetup_SetupA_Trigger = new SceneID("471369F306AB59E87120C959DF8F1687");
		public static SceneID SavingGumoSetup_SetupB_Trigger = new SceneID("48CCE13BF0F54DE2750DBAF438E5AFAD");
		public static SceneID SpiritTreeText_Trigger = new SceneID("49FC43061812BC5B4A06234BCD9B62A4");
		public static SceneID ExpOrb100 = new SceneID("40C0BCD9C0D64CB6F10D8B0AC1509BBF");
	}
	public class MoonGrottoHubSplitA : SceneID {
		public static SceneID HealthCell = new SceneID("49A442904B29B681EAE30083CC728682");
		public static SceneID PetrifiedPlant = new SceneID("404E79B8B3AA56A4502BBC65E687C68D");
	}
	public class MoonGrottoHubSplitB : SceneID {
		public static SceneID BombableWall = new SceneID("47C42DBC71D64A396DA335C9FA647BA2");
		public static SceneID ExpOrb100 = new SceneID("43A7A98E6165603660941AB7AFAEFAAE");
		public static SceneID PetrifiedPlant = new SceneID("4424A5189E3D47832514A731F35298B8");
	}
	public class MoonGrottoHubSplitC : SceneID {
		public static SceneID ExpOrb200 = new SceneID("4898D32AE99BB0F9F1225105774F36B1");
		public static SceneID ExpOrb100 = new SceneID("44CAFCB7D26D4BD37268E568DDBFE29D");
	}
	public class MoonGrottoLaserIntroduction : SceneID {
		public static SceneID GumoAnimationLaser_Trigger = new SceneID("4D3D4D6B73884F9E826607D517279698");
		public static SceneID ExpOrb100 = new SceneID("4F7F8887C8F9C8F65BC8D1F3D778DCB3");
		public static SceneID PetrifiedPlant = new SceneID("4298582AF2B00DFDD736F19CA9CC13AC");
		public static SceneID StompableFloor = new SceneID("48DFF9BBFB3343BC3FA98F1BCE225383");
	}
	public class MoonGrottoLaserPuzzle : SceneID {
		public static SceneID EnergyDoorFourSlots = new SceneID("4956B8CD0CC656381A4EFC8F227EA488");
		public static SceneID AbilityCell = new SceneID("43266B391632B54896F3B5D3AF810F8D");
		public static SceneID PetrifiedPlant = new SceneID("4E0A2AE745777B2AC2F8883A95E28BAB");
	}
	public class MoonGrottoLaserPuzzleB : SceneID {
		public static SceneID BombableWall = new SceneID("4AC73726C1D344E60FC8860CC511F1B0");
		public static SceneID EnergyCell = new SceneID("4CA99963CE498830F9E8D2F7C420ED87");
		public static SceneID ExpOrb200 = new SceneID("4008827182E59D94E54F985CC84B76AF");
	}
	public class MoonGrottoMovingPlatformSideways : SceneID {
		public static SceneID Mapstone = new SceneID("48C8E7AE01F81DA869EA6F24ED0952B8");
		public static SceneID EnergyCell = new SceneID("4F5730A9E55B4E419BFC9B99E07908B9");
	}
	public class MoonGrottoMovingPlatformVertical : SceneID {
		public static SceneID DoorWithTwoSlots = new SceneID("4A841DE78CCF9E558C6523E98DB5F1B9");
		public static SceneID Keystone = new SceneID("4B4A39917A4397492854F2400B464380");
		public static SceneID ExpOrb100 = new SceneID("425ACFB7ED92B223ADBE68601DEFFA90");
	}
	public class MoonGrottoRopeBridge : SceneID {
		public static SceneID GumoBridgeSetup_Group_Trigger = new SceneID("447F7BE6FCACB9C5AD68FED5AFB44CAA");
		public static SceneID GumoGiftSetup_SeinAbilityRestrictZone = new SceneID("44EA6631D657FA85F35F67E2F74EDD85");
		public static SceneID GumoGiftSetup_Timeline_Trigger = new SceneID("405AD4AB948722BCBEBF40DF2434B0A6");
		public static SceneID GumoGiftSetup_Trigger = new SceneID("459423F8E41058B1993A228DC5AA1F9C");
		public static SceneID EnergyDoorTwoSlots = new SceneID("41DE3596FB10271A1564D6A577902280");
		public static SceneID AbilityCell = new SceneID("49A9FA87DC39CF9EE4412B9C39D211B4");
	}
	public class MoonGrottoSecretAreaA : SceneID {
		public static SceneID HealthCell = new SceneID("4DF859675BC937C63885DEC0285F41A6");
		public static SceneID ExpOrb100 = new SceneID("40B52347FCA8045870DAB825024A358A");
	}
	public class MoonGrottoShortcutA : SceneID {
		public static SceneID EnergyDoorFourSlots = new SceneID("4AA6DB4A1DD19E51E65780E21367BD8C");
		public static SceneID HealthCell = new SceneID("4915E28AE8A8988D83B8FEDE3BB4498A");
		public static SceneID ExpOrb100 = new SceneID("46B0EB59B022D6DD8722ECFCF043C189");
		public static SceneID AbilityCell = new SceneID("4E9899EA19CECD1365DEB358D5EF87A4");
		public static SceneID PetrifiedPlant = new SceneID("4CB406D5329B283B3357A03306015F8D");
		public static SceneID Creep = new SceneID("4569EF405F21DF1745F2E8B5729D718E");
		public static SceneID StompableFloor = new SceneID("46B86766E943CD55661E1801641910A3");
	}
	public class MoonGrottoStomperIntroduction : SceneID {
		public static SceneID ExpOrb200 = new SceneID("40CDC03182503910558011584ABF7AAD");
		public static SceneID AbilityCell = new SceneID("40F5A4D155CB64DB2BF8EBEFA0EE40BF");
		public static SceneID Creep01 = new SceneID("4B32F4B406BCC74F3256B5A3C138D09D");
		public static SceneID Creep02 = new SceneID("45C74EBCB4B82EB33F7838F4C2E77C91");
		public static SceneID Creep03 = new SceneID("47793DB84D7E446414ED5831FF6C1A8B");
		public static SceneID Creep04 = new SceneID("4F1B3F02B14467103644A1BC5EE59782");
		public static SceneID Creep05 = new SceneID("49BB3DB9AE6E801931A552CA08D3A3B5");
		public static SceneID Creep06 = new SceneID("479485DBA5E07CFC0241FB23617BD092");
		public static SceneID Creep07 = new SceneID("46C030D8A565F0B4C641C449DB5147AC");
		public static SceneID Creep08 = new SceneID("4E2DED8BA3A83DDB8ADD7C04760F95BC");
		public static SceneID Creep09 = new SceneID("40F1C4BE63750D0A116D780DF5090BA9");
		public static SceneID Creep10 = new SceneID("4FE3954264806359515A7CDDF37EDC94");
		public static SceneID Creep11 = new SceneID("430D842D6DC1CA81339843064561518C");
		public static SceneID Creep12 = new SceneID("460051A97D7C6EB13C87C979C4CF568B");
		public static SceneID Creep13 = new SceneID("4F587DCBEBF01B32CDCE285D4DFE4482");
		public static SceneID Creep14 = new SceneID("42A9C28ED75A7A325AFB2B3A53DBBFA5");
		public static SceneID Creep15 = new SceneID("414952D6CE4E1C9A7A3F9120F659319A");
		public static SceneID Creep16 = new SceneID("4F20CFC432CBAF890B462EA35348F68C");
		public static SceneID Creep17 = new SceneID("4A89A9E53B29514AA242C02BFBBC9888");
		public static SceneID StompableFloor = new SceneID("41387A1BCD1ACE782AC0CAF1682DC199");
	}
	public class MountHoruBackgroundA : SceneID {
		public static SceneID ExpOrb200 = new SceneID("49FA6E214F5BE2FCFE8FCCE1A3D429AB");
	}
	public class MountHoruBigPushBlock : SceneID {
		public static SceneID BombableWall1 = new SceneID("46FFD8DA5CD0E2B85F8BE544C1B56A8A");
		public static SceneID BombableWall2 = new SceneID("4F412F076BEFF857315465303158F790");
		public static SceneID BombableWall3 = new SceneID("400255EE216E9A3E985B8CD5B6F24A9E");
	}
	public class MountHoruBreakyPathBtm : SceneID {
		public static SceneID BombableWall1 = new SceneID("4349D9F54DF52CBB7464F64DAC53E5A4");
		public static SceneID BombableWall2 = new SceneID("477A20624FCB7398627573FCAFB3F1B5");
		public static SceneID BombableWall3 = new SceneID("459FE03A91A279CC3F93C2110716D5B5");
		public static SceneID BombableWall4 = new SceneID("42F3327F8CFB072ACB40AC2B254B309F");
		public static SceneID BombableWall5 = new SceneID("428F6D5AF32234B479CCC150160084A4");
		public static SceneID BombableWall6 = new SceneID("4753204AD8208C6AA019C269C3DEE5B3");
		public static SceneID BombableWall7 = new SceneID("41B88ECD2F7156B949D9A867E8141E8D");
	}
	public class MountHoruBreakyPathTop : SceneID {
		public static SceneID RespawnBlocksSetup_Trigger = new SceneID("49E9437E4BAE824001E5E172F05B77AF");
		public static SceneID BombableWall1 = new SceneID("48CC8665B8F6D8403AA4B54E70FED893");
		public static SceneID BombableWall2 = new SceneID("4D82170B71BC588C217BFABE98F7B195");
		public static SceneID BombableWall3 = new SceneID("42083FF10EE95A9C5F4FD769864127B6");
		public static SceneID BombableWall4 = new SceneID("4FE7D545C8E9B3E830A5EEFDF78AAFB7");
		public static SceneID BombableWall5 = new SceneID("4C711B91C7A9959928E8AA3676420ABA");
	}
	public class MountHoruHubBottom : SceneID {
		public static SceneID ExpOrb200_1 = new SceneID("432348448D985A015111F1B893C0E2B6");
		public static SceneID ExpOrb200_2 = new SceneID("48A4954AD94ECE3B1B31FF7BC4945580");
	}
	public class MountHoruHubMid : SceneID {
		public static SceneID ExpOrb200_1 = new SceneID("4AD9E9844722483F96EB8086B1D11B91");
		public static SceneID ExpOrb200_2 = new SceneID("4143D0BAD034BB5C562A85C26D0DE384");
		public static SceneID Creep1 = new SceneID("40C6108FFEA366DA7747597A01B464B3");
		public static SceneID Creep2 = new SceneID("4548068F0E1532228BE0293164B9D8A2");
		public static SceneID Creep3 = new SceneID("473D778C16D009361832C48994A28FB7");
		public static SceneID Creep4 = new SceneID("40C7DB234510B9E555A683F42F4D3386");
	}
	public class MountHoruHubTop : SceneID {
		public static SceneID BreakableWall = new SceneID("4D6C1C2B652D69623DEF9C9175750FB2");
		public static SceneID Creep = new SceneID("49BA9AF621629539D5707D1E9C384DA6");
	}
	public class MountHoruLaserPuzzle : SceneID {
		public static SceneID ExpOrb200 = new SceneID("4D5B1834188CF3B84C1E5E0B17AEB894");
		public static SceneID RollingBall_resetPosition_Trigger = new SceneID("42EC9FC3B4A86183CC70A87EDBEA61BD");
	}
	public class MountHoruLaserTurretsR : SceneID {
		public static SceneID BombableWall = new SceneID("412862A73F4ECABE6236B539F1CA3D99");
		public static SceneID ExpOrb200_1 = new SceneID("49D930AD9BE6FC74871574250DBF23B3");
		public static SceneID ExpOrb200_2 = new SceneID("44D667F9150B1F69D57FC5EA670E12B0");
	}
	public class MountHoruMovingLaser : SceneID {
		public static SceneID WaveSetup_Trigger = new SceneID("4F43E0C08F8DD50F86EBEC851220F2AD");
		public static SceneID BombableWall = new SceneID("40FF8000F3D10E37D27AB761EAF31FBD");
		public static SceneID ExpOrb200 = new SceneID("40A13BBFDAF73F689EC6BDCCB04BBF8A");
	}
	public class MountHoruMovingPlatform : SceneID {
		public static SceneID PetrifiedPlant = new SceneID("40E506B104CBC18DA34A96BD8B70D9BC");
	}
	public class MountHoruStomperSystemsL : SceneID {
		public static SceneID Mapstone = new SceneID("4BD7F24DB83857AD2C6EB15037163988");
		public static SceneID ExpOrb100 = new SceneID("459D33AA216BD45949267A17338C8FA9");
	}
	public class MountHoruStomperSystemsR : SceneID {
		public static SceneID EnergyCell = new SceneID("45F3ECB3CCE9DBADEB15D6A78F9269BE");
	}
	public class NorthMangroveFallsGetDash : SceneID {
		public static SceneID EnabledByDarknessLifted_NaruStory_Trigger = new SceneID("4F767E9AD15BD2A48983CDC5C9036595");
		public static SceneID EnabledByDarknessLifted_NaruStoryTop_Trigger = new SceneID("40491B45A64420A44AF16A754DA1A487");
		public static SceneID Mapstone = new SceneID("424D5FE459EA408810D4C29B6A6C8DAE");
		public static SceneID PetrifiedPlant = new SceneID("418500C69E8CAE7F14F722175C03C08B");
		public static SceneID LeverNaruStatue_GoesLeft = new SceneID("43801A22028508D9530EA2A20C60789C") {
			Children = new List<SceneID>() {
				new SceneID("4A4A9713AD3F88D32BAED0E1B6B9399F") { Name = "Deactivate" },
				new SceneID("49DF37A38C5875ED081754C4051F22BB") { Name = "Animator" }
			}
		};
	}
	public class NorthMangroveFallsIntro : SceneID {
		public static SceneID NoSoulFlameZones_Trigger = new SceneID("49FC6453A5D2A7929AB293A31E18BB81");
		public static SceneID ExpOrb100 = new SceneID("48DD36AA196A9E89F9A530AECF6988BE");
		public static SceneID AbilityCell = new SceneID("41565E76B8B341C60D8EFDABE797318E");
		public static SceneID SpiritTorchStart = new SceneID("47500BE4F13BC5B3FE1D4D34D70C79A0") {
			Children = new List<SceneID>() {
				new SceneID("463070778691949B53810714254B208E"),
				new SceneID("46621D65D4A21989897837692667818D") { Name = "Activator" },
				new SceneID("41F6937A4E98269416AB2C1AE83822B0") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorch1 = new SceneID("4C2AFD4471B99CD72D1D4CDFF4002CA0") {
			Children = new List<SceneID>() {
				new SceneID("41F4750BB989895BC5C69F12B70233A9"),
				new SceneID("4CFD6EF78B72F2200EDF932BEC00F3A0") { Name = "Activator" },
				new SceneID("4D0282723BC798D96F7723AA00736FAE") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorch2 = new SceneID("42587F47444836A14EC605A75959D7BE") {
			Children = new List<SceneID>() {
				new SceneID("4DF18636DF001325C99C36F7152979A3"),
				new SceneID("46740FD188562B3FF715512F4240E9B6") { Name = "Activator" },
				new SceneID("4B49143B402D7D8415E9C8713CF95893") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorchPlatform = new SceneID("4BCCF02B795DA6F2BA2A84FCA8780BA2") {
			Children = new List<SceneID>() {
				new SceneID("43334120BB6EBCAF3A024C090BD7FDAF"),
				new SceneID("494E4784D02C547CB08421BCFD49569D") { Name = "Activator" },
				new SceneID("4A1294F811B9CEAB8D3DB9F45C5345AD") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorch4 = new SceneID("47C2B7BEB6AA12FD5128783F562F149B") {
			Children = new List<SceneID>() {
				new SceneID("488B32F9E892CF0C5F5EC392A602C9AD"),
				new SceneID("41B25ACFE5B124ED151C1DD49D933D9D") { Name = "Activator" },
				new SceneID("4E28311010C16F66C7CAC899EFD78FA3") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorch5 = new SceneID("41E06E69961B8DEC4B9AD23FF981C2B6") {
			Children = new List<SceneID>() {
				new SceneID("41A7635B7240DFED08373BDB4006F98F"),
				new SceneID("498F837EB34F6EB90EE6463D6F0EDD87") { Name = "Activator" },
				new SceneID("4672258A8AB8DA45BDC077D7464D56AA") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorch6 = new SceneID("47C6173E37FA67E31BCE09C64BF9C1A1") {
			Children = new List<SceneID>() {
				new SceneID("46FDC92500D654E9807F7249C2987EA0"),
				new SceneID("433CFA5E16622CF007B3C734849C0EAD") { Name = "Activator" },
				new SceneID("49743E76F1638C183269A3F37AF1E8A2") { Name = "Animator" }
			}
		};
		public static SceneID SpiritTorchTop = new SceneID("4137F45F06C5143A19F2B21717730797") {
			Children = new List<SceneID>() {
				new SceneID("4373920660D327859955FAB9F8615DBB"),
				new SceneID("424E4084617803F25098B6EBFC3233B9") { Name = "Activator" },
				new SceneID("47274FD209216A267BB1D71109E2929D") { Name = "Animator" }
			}
		};
	}
	public class NorthMangroveFallsLanternIntro : SceneID {
		public static SceneID NaruStorySetupA_Trigger = new SceneID("4514363815022B283FCD29E51E9C9184");
		public static SceneID ExpOrb100 = new SceneID("414B482DD0EEA4603D7DF4F096DB8A9C");
	}
	public class SorrowPassEntranceA : SceneID {
		public static SceneID Mapstone = new SceneID("4C2462967B837BEF4120188E8123E4A0");
		public static SceneID ExpOrb100 = new SceneID("41A7D0E6797703125363E0B69E0FB9BD");
		public static SceneID PetrifiedPlant = new SceneID("4474246BF2BBA6CDB6BA2D921FC3CA9E");
		public static SceneID StompablePlatform = new SceneID("4BC58372169CE4D3AAD57366DFA0379C");
	}
	public class SorrowPassEntranceB : SceneID {
		public static SceneID SpiritTreeTextA_Trigger = new SceneID("4B47585F35EF796D19A87B0223C90A88");
		public static SceneID SpiritTreeTextB_Trigger = new SceneID("4DCCC671423F137DEF6EA0BE0978428F");
		public static SceneID SpiritTreeTextC_Trigger = new SceneID("401EC4050F1437A675F1576A8367B898");
		public static SceneID StompablePlatform = new SceneID("4B15632B7E874747D6E5C68F4B276488");
	}
	public class SorrowPassForestB : SceneID {
		public static SceneID StorySetup_LiftFogSequence_Action_Trigger = new SceneID("4166EF031AC94D3EF1BBB7A94EAE8D91");
		public static SceneID StorySetup_LiftFogSequence_Trigger = new SceneID("44EDD6D1EF1CE8B27E3F2A16AAD1FC9F");
		public static SceneID DeactivateJumpHigherHint_Trigger = new SceneID("427C7A47D9973C4EE9A294D91E0F868E");
		public static SceneID ExpOrb100 = new SceneID("4C7FE1CA6C74597A85112FBD03A599A7");
		public static SceneID StompableFloor = new SceneID("4784D1BCECCB14CA412E470880C32497");
	}
	public class SorrowPassValleyD : SceneID {
		public static SceneID RedBulb1 = new SceneID("45F748B1099159EE34A90D938010DB88");
		public static SceneID RedBulb2 = new SceneID("47E0F05B0A47B1BE02400343259219B6");
		public static SceneID RedBulb3 = new SceneID("4FC9C30094486B422E71B37711034598");
		public static SceneID RedBulb4 = new SceneID("4EF8DFA104573D50788F9881360F7784");
		public static SceneID ExpOrb2001 = new SceneID("46429465AB154DC5386F078A1E5DE08D");
		public static SceneID ExpOrb2002 = new SceneID("4CADE1E964DB442709CA07235095AFAA");
		public static SceneID AbilityCell = new SceneID("4FA12B71C803368DE9571DBB3831BC9A");
	}
	public class SouthMangroveFallsGrenadeEscalationBR : SceneID {
		public static SceneID ChargeFlameWall = new SceneID("4A3528D1ABAF5F961D70171BFA9B75B6");
		public static SceneID ExpOrb100 = new SceneID("420150217B6725DBB2BCAAE8156AE78B");
		public static SceneID AbilityCell1 = new SceneID("4D47A520A301E7FAED0A6A9761192789");
		public static SceneID AbilityCell2 = new SceneID("47C3390AE9E2FA9E82FE6F9201795CB0");
	}
	public class SouthMangroveFallsStoryRoomA : SceneID {
		public static SceneID ObjectiveSetupAction_DeactivateRestrictZones = new SceneID("4A6E3C3306EEB663BE3DCB418537AA80");
		public static SceneID ObjectiveSetupAction_Trigger = new SceneID("4E0B20EB53F38A03AD3ACB89B4937197");
		public static SceneID ExpOrb100 = new SceneID("449B2FB08DBF35CBF7F870F007B248B7");
	}
	//Add 100xp entity
	public class SpiritTreeRefined : SceneID {
		public static SceneID SeinAbilityRestrictZone = new SceneID("4ECA00B78E22CCE6F62C0F5C311B1291");
		public static SceneID ReachSpiritTree_Trigger = new SceneID("4A3F38030FD183F194680077E2ADEBBF");
		public static SceneID ChargeFlameWall = new SceneID("4115596F69D3F2637BDAB047E17011AA");
		public static SceneID ExpOrb100Pickup = new SceneID("44CF75D30AEAEE9C3DECC7394F35DF84");
	}
	public class SunkenGladesBackgroundB : SceneID {
		public static SceneID ExpOrb15 = new SceneID("49B35E8028EED6921FBB100D9890D79E");
	}
	public class SunkenGladesEnemyIntroductionC : SceneID {
		public static SceneID MapHints_Trigger = new SceneID("4A35CE25BAB38C6931F2D825F69CDE83");
		public static SceneID EnergyCell = new SceneID("439ED3AA504548A0D99342DB969A4FBE");
		public static SceneID RedBulb1 = new SceneID("43DA0771B81B3C1A4D4B044930319D96");
		public static SceneID RedBulb2 = new SceneID("4AE289C2337B10CA9F7309C2F353F0A8");
	}
	public class SunkenGladesIntroSplitA : SceneID {
		public static SceneID Keystone = new SceneID("4C475939548601B0FB9966635678B0BC");
		public static SceneID ChargeFlameWall = new SceneID("4A419C9D7853E50BC9CC3A4C65B31989");
		public static SceneID Creep = new SceneID("4ED390C049094115F50E3AF57DE268B5") {
			Children = new List<SceneID>() { new SceneID("46DDB853903454624370C0606D092BBE"),
											 new SceneID("45C860CA7972BAD29A1715CBB12841A0"),
											 new SceneID("42E4C62429D88A15EDF28B3F567DAC8C"),
											 new SceneID("439724044EA7CF08A4A2183C9CD9D89B") }
		};
		public static SceneID DoorWithTwoSlots = new SceneID("45669AABB68ED164A1373739CE27BFBE");
		public static SceneID ExpOrb200 = new SceneID("492756A0419BBF912F9E9B27BDB73EB8");
		public static SceneID ExpOrb100_1 = new SceneID("45C40E763E5E308C3587F4DA5A01E48B");
		public static SceneID ExpOrb100_2 = new SceneID("4100B81D8EEA0DDA06B2395595D418AC");
		public static SceneID RedBulb1 = new SceneID("4BA945C49F3F3E80CE5DE35201F132AF");
		public static SceneID RedBulb2 = new SceneID("4621647E2C2208B7D3EE05DA7706FF94");
		public static SceneID SpiritTorch = new SceneID("4910D2B7359FA9753E1A14B2333041A3") {
			Children = new List<SceneID>() { new SceneID("4007104696780731EC7A610C7A9227AF") { Name = "Animator" },
											 new SceneID("430E6410B3947A79AE78FE1A7CDE1FB3") { Name = "Activator" },
											 new SceneID("4C4FA4BE865ABDF9A575E980D6DECFAE") }
		};
	}
	public class SunkenGladesIntroSplitB : SceneID {
		public static SceneID SpiritWellHintSetup_Trigger = new SceneID("46D7E4D3B94C4FC71184C8B1ED93D5B3");
		public static SceneID Keystone = new SceneID("4FFCE57D9489DB41C6B81037ECEBB6BA");
		public static SceneID NaruStatueHintSetup_Trigger = new SceneID("40C8354D4F6DC7A009171549D5A33E8B");
		public static SceneID NaruStorySetup_DeactivateRestrictZones = new SceneID("4C4C003EBAA5C1E2960451E349F8E895");
		public static SceneID NaruStorySetup_Trigger = new SceneID("48BA9B844D681969E8554943BCF35897");
		public static SceneID AbilityCell = new SceneID("4DEBD90CDA7ABF939560FD6B83DF049F");
		public static SceneID ExpOrb15 = new SceneID("4DF41D6CE1D7DDE31E001F93B159D986");
		public static SceneID SpringCreep = new SceneID("4A48F32F439A6A00AB7504A5E62736B5") {
			Children = new List<SceneID>() { new SceneID("408B254B2572EA735132F38717E5B691"),
											 new SceneID("4A5EAE76B87A6F03E4F079655E5B2DA5"),
											 new SceneID("456F7A4AD8C3DCFD0A23A49DDEEEC68E"),
											 new SceneID("421078ADBAC1BA556F4EC72782FAB582") }
		};
		public static SceneID CreepBottomBL = new SceneID("4D97D2584572ED74A14E6FC4576F838F");
		public static SceneID CreepBottomBR = new SceneID("4A0444CC36337745E3B97C046F6A5B88");
		public static SceneID CreepBottomM = new SceneID("40F89FC252E52AA6376A13D735375B82");
		public static SceneID CreepBottomTL = new SceneID("49A5CBF49FBBF56E2D9FCAA430B2BAA3");
		public static SceneID CreepBottomTR = new SceneID("448757C955AA6E73DF888533A454CA9B");
		public static SceneID CreepTopBL = new SceneID("431CAE019ED6BE9BD45E3426109CF58C");
		public static SceneID CreepTopBR = new SceneID("43076535B1BB2689AC5CA60EE1F7D98B");
		public static SceneID CreepTopM = new SceneID("4D674617516FD7F1B9CB5D26BA6720BF");
		public static SceneID CreepTopTL = new SceneID("4F48E391C0A25D19DD56ADFDDFF8B9A2");
		public static SceneID CreepTopTR = new SceneID("49AE23D67D72B17ADE220F24B3676A88");
		public static SceneID SpiritTorch = new SceneID("4ED420D50E9D6353624A57DAF192599B") {
			Children = new List<SceneID>() { new SceneID("46A3AE3181F1F2AD9920351DA3102E9C") { Name = "Animator" },
											 new SceneID("4FF1B4C4EE19D5659D9AB365091500B7") { Name = "Activator" },
											 new SceneID("48FE6D5E16471832708BD065AA9598A1") }
		};
	}
	public class SunkenGladesObstaclesIntroductionStreamlined : SceneID {
		public static SceneID CreepHanging = new SceneID("4F27BCE613DF87839D9F0F0E21084E8A");
		public static SceneID CreepBelowHanging = new SceneID("47A6F829D65D745A97D5D61FC7F1E2BA") {
			Children = new List<SceneID>() { new SceneID("420348969DE59897098E462899315CA4"),
											 new SceneID("407C2825A106716674BBC9D9D37272A9"),
											 new SceneID("4CBA319983D3DBEFA4110AA0DF69C889"),
											 new SceneID("494AA06A2884DA5F8F083F063FE6E184") }
		};
		public static SceneID CreepTopGround = new SceneID("4D3AACC6C56ED164140B50BD373388A5") {
			Children = new List<SceneID>() { new SceneID("46DCE0DCB1316A3F545C896B48F7B8A7"),
											 new SceneID("4069087E523F01C50015473A891C8AAB"),
											 new SceneID("48822C256E8F94B7036BE62ADEC48A90"),
											 new SceneID("4A93A1347797B654BA6BBF3029D5C5BD") }
		};
		public static SceneID CreepMiddleGround = new SceneID("45B34EED3F75B756F24F689921DE9F85") {
			Children = new List<SceneID>() { new SceneID("48C3C7B74939BB1543AF4147207BDEAD"),
											 new SceneID("4DD52EF4A745AFF5A534EC6EEB7AF294"),
											 new SceneID("424EC19830820A11BC74A52E5F36F6B2"),
											 new SceneID("4204E8FBA96FED917AF801D8F62B8A9E") }
		};
		public static SceneID CreepMiddleTop = new SceneID("4271F32BD4D4A13DD35BD91A2D8C4183");
		public static SceneID DoorWithTwoSlots = new SceneID("4F42A3632371D15EFE5F6B669A612B98");
		public static SceneID CreepBL = new SceneID("4C3268B25C746B6F272CD95C5C812EA2");
		public static SceneID CreepBR = new SceneID("4932A953022F9C7B474F5B7B920C91B8");
		public static SceneID CreepM = new SceneID("41D5B05C86D98EA225DADF9B1BDC09B8");
		public static SceneID CreepTL = new SceneID("45A687DC307CC29EC7629FC18E435A8E");
		public static SceneID CreepTR = new SceneID("4C729FFB86E80F6200F70B584B4DB286");
		public static SceneID RedBulb = new SceneID("490F022CAA64283FDBDB9F5FF553259F");
	}
	public class SunkenGladesOriRoom : SceneID {
		public static SceneID NewLines_andBroughtHopeToOurForest_Trigger = new SceneID("49DDD3D79E7CF469DE7262C07878A190");
	}
	public class SunkenGladesRunaway : SceneID {
		public static SceneID ObjectiveSetup_Trigger = new SceneID("403F1AEB7A6119AD9D64112614E9B385");
		public static SceneID EnergyDoorFourSlots = new SceneID("43A40D50BE779223A2A26CD46B5628BB");
		public static SceneID ExpOrb200 = new SceneID("4C26AFB84C5D17FB807A3F242B52489A");
	}
	public class SunkenGladesRunning : SceneID {
		public static SceneID AbilityCell = new SceneID("43829312910BDAD8598A0AB8D33812AC");
	}
	public class SunkenGladesSpiritCavernB : SceneID {
		public static SceneID ObjectiveSetup_Trigger = new SceneID("44528D039AA97EDEB4E631351A9E5A89");
		public static SceneID DoorWithFourSlots = new SceneID("4C5CFAC66B0A41074D8A4178841D5EB2");
		public static SceneID Keystone1 = new SceneID("405D07E8C42CAD4C1FF5E6A8B576D397");
		public static SceneID Keystone2 = new SceneID("4BDBE390B91BFA61794AA22C819FE5A8");
		public static SceneID Keystone3 = new SceneID("4CA70349A5209BD0BAF15FA76B5AD283");
		public static SceneID Keystone4 = new SceneID("4FB7A39D9BE844F58B26591ABD597E85");
		public static SceneID Mapstone = new SceneID("498A9179FF77BCB9BD2E4818DF0770B0");
		public static SceneID AbilityCell = new SceneID("46B4969FCEB745703602FBFAE0A467B2");
		public static SceneID RedBulb = new SceneID("4E44EA678FA1CEECBB40B9C0CAF62682");
		public static SceneID CreepMushroomLT = new SceneID("45AB2E05E3DC87D66234DD3A6F2BCA95");
		public static SceneID CreepMushroomLB = new SceneID("4DF340CC7846C658AEC2F9705FB2C6AC");
		public static SceneID CreepMushroomM = new SceneID("4D65A16E6B745EA43DA3E866B76AC3BC");
		public static SceneID CreepMushroomRT = new SceneID("45D13D10574AE27B4148CEE288308DB9");
		public static SceneID CreepMushroomRB = new SceneID("42396EBD253CD5DAAC8C31F301DF8BA8");
		public static SceneID CreepWallBL = new SceneID("4DB7DA7939E46F490A902D1B5D1571AF");
		public static SceneID CreepWallBR = new SceneID("4C1A20BCA51F5264BE980CB890EA33AF");
		public static SceneID CreepWallM = new SceneID("488989A85C039D87D8B278614D99A1BF");
		public static SceneID CreepWallTL = new SceneID("45658252F372AEEFC745E89C61830A99");
		public static SceneID CreepWallTR = new SceneID("467D03E57DAACDFB65252ED1BEACEA83");
	}
	public class SunkenGladesSpiritCavernLaser : SceneID {
		public static SceneID StompableFloor = new SceneID("45FD715F48CE32E33691E284BB3AEE94");
		public static SceneID EnergyDoorFourSlots = new SceneID("443F707AEF7433D76AEDC8C3C7060BA6");
		public static SceneID EnergyCell = new SceneID("42D22E6D340FEFCDD46F13ECD5F6FA85");
	}
	public class SunkenGladesSpiritCavernSaveRoomB : SceneID {
		public static SceneID ObjectiveSetup_Trigger = new SceneID("4EB8BB129C3C5859BCD31954F4B816A7");
		public static SceneID Keystone = new SceneID("4FCA0C2B06F2341D2CBFD7D3271DF2AE");
		public static SceneID EnergyCell = new SceneID("4B2A9B64A596B52D22D6F732A74946B8");
	}
	public class SunkenGladesSpiritCavernsPushBlockIntroduction : SceneID {
		public static SceneID GumoFG_Setup_Trigger = new SceneID("4A0B5824C938E34AC1C9FF6C6FBFC78A");
		public static SceneID Keystone = new SceneID("4E6531353A113E270A285B3B6AFC8CB2");
		public static SceneID ExpOrb15_1 = new SceneID("477E93371AD2ED468633046D72E9238C");
		public static SceneID ExpOrb15_2 = new SceneID("42A782A405BBF4FB4E920152B3FEFDA4");
		public static SceneID CreepLT = new SceneID("45C711456E495EAD8BC4DF69FE5232B1");
		public static SceneID CreepLB = new SceneID("4C76880636366658490FCD59C091B28D");
		public static SceneID CreepM = new SceneID("4B221356931E63D52EEB4657AFC87393");
		public static SceneID CreepRT = new SceneID("446DFD3B46F2DCBDFFDC5A37DF405CBD");
		public static SceneID CreepRB = new SceneID("496641944468BFB767252713B25F63BA");
	}
	public class SunkenGladesSpiritCavernWalljumpB : SceneID {
		public static SceneID StoryLines_fadeInSpiritA_Trigger = new SceneID("470F4C438BE2C6E0E24E201AF7C265B6");
		public static SceneID StoryLines_fadeInSpiritB_Trigger = new SceneID("4DA1250335521F1260C3A45713295B8D");
		public static SceneID StoryLines_fadeInSpiritC_Trigger = new SceneID("46A61D1A3BA48E6D880D4DA061558F8D");
		public static SceneID StoryLines_ourLights_Trigger = new SceneID("40C75E631E1DAD03751E3D008A7CF6AE");
		public static SceneID StoryLines_thatNight_Trigger = new SceneID("4E2596FA425D81FB0A52F9AC5EFA55A2");
		public static SceneID StorySetups_storyTextWith_Trigger = new SceneID("401529B74107F5DDA52D191CE9C50381");
		public static SceneID EnergyCell = new SceneID("4E9AB5B6CC78DAE03360041CDD845D91");
		public static SceneID ExpOrb200 = new SceneID("4D662761912CC1AF2F61CAAF0113CF99");
	}
	public class SunkenGladesWaterhole : SceneID {
		public static SceneID HealthCell = new SceneID("4F96320A10D65D38D0BDF5FD808B0787");
	}
	public class ThornfeltSwampA : SceneID {
		public static SceneID Setup_group_Trigger = new SceneID("462507887960517396B4B68091E337B9");
		public static SceneID HealthCell = new SceneID("45CA41DDC04D0698E4BA5452DA42F987");
		public static SceneID ExpOrb200 = new SceneID("4B1FBC37A90C1795369F306D22C3E7AF");
		public static SceneID ExpOrb100 = new SceneID("43D651531028C4BD6773C33BAE2A95A7");
		public static SceneID StompableFloor = new SceneID("4AE910D126629EAED3B4289435DDE6BE");
		public static SceneID StompablePlatform1 = new SceneID("4E85A29784E45BD8E0D131225257C1AA");
		public static SceneID StompablePlatform2 = new SceneID("4ACE01F6BFBF86945695623023FD3F94");
		public static SceneID SpiritTorch = new SceneID("4E38451EABD405F2AB8B38AD77DFDC94") {
			Children = new List<SceneID>() { new SceneID("487BF5682E813612AA2859F6B900F5A2") { Name = "Animator" },
											 new SceneID("4CDEF1D1AB0FE18489AADFEF49DB009F") { Name = "Activator" },
											 new SceneID("42672E78F4AC3CD03D142226007DA5BF") }
		};
	}
	public class ThornfeltSwampActTwoStart : SceneID {
		public static SceneID GumoSavesSein_Trigger = new SceneID("48B2F8E4920795969FF6A17EB4C231A6");
		public static SceneID BombableWall = new SceneID("418310C0D072DDDAA973C5C04FACB987");
		public static SceneID DoorWithTwoSlots = new SceneID("43FCE880FF50CFC4DB70A2CA188F27A2");
		public static SceneID EnergyCell = new SceneID("4D97DF30EC4DC1DBA29E989E54169282");
		public static SceneID ExpOrb100 = new SceneID("4EBE6F98F9486C22DEDE7E43EA0CF096");
		public static SceneID AbilityCell = new SceneID("4AC2C4EFE8B3DEFDC5E78CD9FC63D597");
	}
	public class ThornfeltSwampB : SceneID {
		public static SceneID GumoMortarsSetup_BombableWall = new SceneID("4C55BF10CD44357931E3116DC46F03BC");
		public static SceneID GumoMortarsSetup_Trigger = new SceneID("4331B4D590CB8F0DC4EE5B647343B8AE");
		public static SceneID BombableWall1 = new SceneID("4BCB23535D6A78C944510B231FBC3C83");
		public static SceneID BombableWall2 = new SceneID("437E8EF7E8F23DE8DBDF0C2CC7A954AD");
		public static SceneID BombableWall3 = new SceneID("4AEF3DE4E36292B9732067BFA38886B8");
		public static SceneID BombableWall4 = new SceneID("4209B88D393899DB8A740FD258A487A2");
		public static SceneID RedBulb1 = new SceneID("4219CD2073BE23208B61FCFA95A7B2AD");
		public static SceneID RedBulb2 = new SceneID("45DF22B0EF21F4B54508FA2706FD77B2");
		public static SceneID RedBulb3 = new SceneID("48611624142B651CEC4EB030494985A0");
		public static SceneID AbilityCell = new SceneID("4B82D550F04E11388658FFAC5EDEFD85");
		public static SceneID PetrifiedPlant = new SceneID("4901D3E6979A9535315A72AA8190D498");
	}
	public class ThornfeltSwampBackgroundA : SceneID {
		public static SceneID ExpOrb200_1 = new SceneID("476DE62D7E1F72798FC5FD244E134AB3");
		public static SceneID ExpOrb200_2 = new SceneID("4BB17FE7D3D7B587777D06FF60B5EE96");
		public static SceneID ExpOrb100 = new SceneID("4F2F0832E2D60D349004F34915884EB6");
	}
	public class ThornfeltSwampE : SceneID {
		public static SceneID Creep1 = new SceneID("44FBFA384D8144FA046348685F10D6A4");
		public static SceneID Creep2 = new SceneID("4C14C53A535A1128E2592E3EB3A26F91");
		public static SceneID Creep3 = new SceneID("4972D953934E3385D8B7D38FAC46F386");
		public static SceneID Creep4 = new SceneID("4BCB97887737486D3498EBDC115DBE99");
		public static SceneID Creep5 = new SceneID("4301BD8D7F9F57B995DF9225FA089AB6");
		public static SceneID Creep6 = new SceneID("4B4A7DED2558A30D0D5C41323B05A1AE");
		public static SceneID Creep7 = new SceneID("47F2E341C96A1DF29F04DC75F3C63F84");
		public static SceneID Creep8 = new SceneID("47C6C737C6F811B37C2969F18671FEB5");
		public static SceneID Keystone1 = new SceneID("4A410CADDFE1BF6BFDC193C44994C7A1");
		public static SceneID Keystone2 = new SceneID("48D73C6E2840C9A7A468441B97BDE99D");
		public static SceneID Mapstone = new SceneID("431480F97E4713F2263FBE795FBA9DBD");
	}
	public class ThornfeltSwampMoonGrottoTransition : SceneID {
		public static SceneID ChargeFlameWall = new SceneID("4A870713127EF76B49A77E0B9FE54ABA");
		public static SceneID ExpOrb100 = new SceneID("4822305A7D5E8DF7546A3BE8C2B1BABF");
		public static SceneID AbilityCell = new SceneID("4D3A934B3094682177D56FBC1570508F");
		public static SceneID PetrifiedPlant = new SceneID("475AC7B0385E2B284F12793E0D914284");
		public static SceneID StompableFloorSwamps1 = new SceneID("4BEFDAA23FE36DC1FC14623F07DEC89A");
		public static SceneID StompableFloorSwamps2 = new SceneID("4605D46C1517C3F9C87D4D03C149D396");
		public static SceneID StompableFloorSwamps3 = new SceneID("4F44A3FC1E4EDEB1E93987A8602EA793");
		public static SceneID StompableFloorSwamps4 = new SceneID("4D44B430C706892D2A9B7D31C3A7CFA8");
	}
	public class ThornfeltSwampStompAbility : SceneID {
		public static SceneID ExpOrb200 = new SceneID("488F9D27B7A9DAFEAA67CA2183AD8996");
		public static SceneID ExpOrb100 = new SceneID("4CDFD856E3037E9FEB86DD3EB87B2194");
		public static SceneID StompableFloor1 = new SceneID("4330564FAE4D0AF80A0732CBE07AB196");
		public static SceneID StompableFloor2 = new SceneID("425BDB54D34087006358158DC48DFEBE");
		public static SceneID SpiritTorch = new SceneID("4F3895A4BE5021A5D1F1864B2E9D4E93") {
			Children = new List<SceneID>() { new SceneID("4D319BBAE5C041873F03FB1FA02B74BF") { Name = "Animator" },
											 new SceneID("4BD121E6B705716AE42B1D7024295F84") { Name = "Activator" },
											 new SceneID("4D32C9FC6C400B3FED4DABEA5CFA309B") }
		};
	}
	public class UpperGladesBelowSpiritTree : SceneID {
		public static SceneID AbilityCell = new SceneID("4E824E85883A5597885054584D11B4B7");
		public static SceneID SpiritTorch = new SceneID("4DB6AFBD2C0BA1F17DBCC83A8E590FAA") {
			Children = new List<SceneID>() { new SceneID("4CA2042D28167C3BE01430356B03A6B2") { Name = "Animator" },
											 new SceneID("44362CB1679345553B7DA498E6E95A9D") { Name = "Activator" },
											 new SceneID("475004292AF59ED1BDF661C8CC57CE82") }
		};
	}
	public class UpperGladesHollowTreeSplitA : SceneID {
		public static SceneID RedBulb = new SceneID("41BF28FB570ED79F4A2970FC3D394B8B");
		public static SceneID StompableFloor = new SceneID("4BDBF6AA8E0242361BE16E37F0FFB6A7");
	}
	public class UpperGladesHollowTreeSplitB : SceneID {
		public static SceneID KuroAct2_Trigger = new SceneID("461B1FC73041EB78F953348BDB11CC87");
		public static SceneID ExpOrb100 = new SceneID("458AB879FDCE654D0E68931444EE2682");
		public static SceneID AbilityCell = new SceneID("468CDCA4E8FDD30D3B6E824884E6A5BD");
		public static SceneID PetrifiedPlant1 = new SceneID("477E4F4DEE891A3F30024494A8921180");
		public static SceneID PetrifiedPlant2 = new SceneID("4B40ECC50597F6DC926C73AC50945BBC");
	}
	public class UpperGladesHollowTreeSplitC : SceneID {
		public static SceneID HollowTreeSetup_Creep1 = new SceneID("4744712C6073604EBD9FDDB152C3C584");
		public static SceneID HollowTreeSetup_Creep2 = new SceneID("4C7AD798EE0285C593591CF5948AECA6");
		public static SceneID HollowTreeSetup_Creep3 = new SceneID("44AC66764EB611EEEF195A2562E57EBE");
		public static SceneID TopOfTreeSetup_Creep1 = new SceneID("44BF678034082DF7E113AA3AE4335BA7");
		public static SceneID TopOfTreeSetup_Creep2 = new SceneID("495181F65408320B67B5CCDA5F436F94");
		public static SceneID TopOfTreeSetup_Creep3 = new SceneID("45B5E47711AF29F1D244EEB6CADEB895");
		public static SceneID TopOfTreeSetup_Creep4 = new SceneID("4593051375987C3AD55DF2D17083EC88");
		public static SceneID TopOfTreeSetup_Creep5 = new SceneID("480D96F88D574405E354A56DF53D0998");
		public static SceneID EnergyCell = new SceneID("4C14714E9A98C14039302DD495230799");
		public static SceneID HealthCell = new SceneID("4451EEE78B67A002D819704E88761CAB");
		public static SceneID RedBulb1 = new SceneID("4EAB086594097098BC774FFDDBB48BBF");
		public static SceneID RedBulb2 = new SceneID("4B4E35598A0E120185CC436017F5CCBE");
		public static SceneID RedBulb3 = new SceneID("4CD6DAB3ECB04EE64478CB6730FDBF84");
		public static SceneID Mapstone = new SceneID("4E4B0B8C428D6D8BF90488F7C68FAE8D");
		public static SceneID Creep1 = new SceneID("4A7A722CECE437476B56ED372D7345BB");
		public static SceneID Creep2 = new SceneID("42022039CB4E6F5D61F9F497F5C8B69A");
		public static SceneID Creep3 = new SceneID("48BB62CFA80482F7D0C8BEEF21AF098D");
		public static SceneID Creep4 = new SceneID("404249E2CD9C52E9D290A20E8FF3D983");
	}
	public class UpperGladesSpiderCavernPuzzle : SceneID {
		public static SceneID GumoFG_Setup_Trigger = new SceneID("4FC9FC78D8AEA993446831D08D2D7692");
		public static SceneID LogSetup_EggHint_Trigger = new SceneID("4E31D001BA870065BF627A33E6DB43B0");
		public static SceneID ChargeFlameWall1 = new SceneID("44AA711B879B23EEA5E3A5F1A5C9B4B1");
		public static SceneID ChargeFlameWall2 = new SceneID("46672E935214EBEC977B9033E776CB82");
		public static SceneID EnergyDoorFourSlots = new SceneID("4CBDF729E87B3317D590F401BA6C4092");
		public static SceneID HealthCell1 = new SceneID("451B8EE047188BEED905E16E08A7C380");
		public static SceneID HealthCell2 = new SceneID("4A1C5290047EE40156D373A4C0C53390");
		public static SceneID RedBulb = new SceneID("4A47763454E7C5E6F3A4C92EDA2FD7A4");
		public static SceneID AbilityCell = new SceneID("47EE6A8EAF3DBD5873AED47CA6A31C99");
		public static SceneID SpiritTorch = new SceneID("4D6D8014E4DA2119945DA74AE2C963BE") {
			Children = new List<SceneID>() { new SceneID("45A95BD246FE6E378B8DD1A7FFCC1EBF") { Name = "Animator" },
											 new SceneID("457FBD4ED8AE8768F502D059F2068FB8") { Name = "Activator" },
											 new SceneID("425ED43BDC51622FF3B330737B9CE594") }
		};
	}
	public class UpperGladesSpiderIntroduction : SceneID {
		public static SceneID ExpOrb100 = new SceneID("4AD7DED1B01C125BC864531E8317F48E");
		public static SceneID Creep1 = new SceneID("475819CF96474ED276F71D9F2720A283");
		public static SceneID Creep2 = new SceneID("47B3B3151BA88034305F32BF6B6603B2");
		public static SceneID Creep3 = new SceneID("4DBDB786A65DC62EBEEF4B8B2CBA418E");
		public static SceneID Creep4 = new SceneID("4AFADA378B13C91C50C728AEA1961E92");
	}
	public class UpperGladesSpiderIntroductionB : SceneID {
		public static SceneID Wall = new SceneID("40A0ECE9E585D7C7F14428C995775B86");
		public static SceneID ExpOrb200 = new SceneID("4DFB6102C4B53F9CD2509D282D2D668B");
		public static SceneID SpiritTorch = new SceneID("4830C2F5E0D72182570ECE19F0531589") {
			Children = new List<SceneID>() { new SceneID("41BF00F2954E46010DE5B407B559058E") { Name = "Animator" },
											 new SceneID("4615F03867229AD142BF1B3CF8D19088") { Name = "Activator" },
											 new SceneID("47A82ABEF1132C3A7AF60B8BE87CDCBE") }
		};
	}
	public class UpperGladesSwampCliffs : SceneID {
		public static SceneID GumoFG_Setup_Trigger = new SceneID("4E58844CCE29FBBB61675BF8CFFB0EBC");
		public static SceneID AbilityCell = new SceneID("417BDDBAEFA5D0135D35A368746CB69D");
	}
	public class UpperGladesSwarmIntroduction : SceneID {
		public static SceneID ChargeFlameWall1 = new SceneID("4A8A7E90D533216053316AA6106DDDA7");
		public static SceneID ChargeFlameWall2 = new SceneID("4A4D2ED8AF6EB42A58D22095F19F7C81");
		public static SceneID RedBulb1 = new SceneID("4419AFD09FCCD0D3C56E3C81819C8296");
		public static SceneID RedBulb2 = new SceneID("4F411D670E948CDA8267E5515FE613A9");
		public static SceneID RedBulb3 = new SceneID("492AD70320DC24D10C9FF1CBE4A6AB91");
		public static SceneID EnergyCell = new SceneID("4004F3A22188912C776C0B0F2112009F");
		public static SceneID ExpOrb100 = new SceneID("44A217C475F7DA896B025BFEAE62C2AF");
		public static SceneID AbilityCell = new SceneID("448F4F814E4D70F1E4B1665914BDB29A");
		public static SceneID PetrifiedPlant = new SceneID("4D5E19E5FE65600F9736E906FE28BF82");
		public static SceneID StompableFloor = new SceneID("45974815C5321D695B4119D19DDA4FB9");
	}
	public class ValleyOfTheWindBackground : SceneID {
		public static SceneID FeatherPickup_Trigger = new SceneID("42E0D18A660AE74E12A82C9772B4569B");
		public static SceneID StompableFloor = new SceneID("42BF70EA62199C5E533CA639C9817986");
	}
	public class ValleyOfTheWindEArt : SceneID {
		public static SceneID Mapstone = new SceneID("4B7C23CA9D54696A563CA6B3FAD2E2BE");
		public static SceneID StompableFloor = new SceneID("450CE11F270206BDAF648697E5448292");
	}
	public class ValleyOfTheWindGauntlet : SceneID {
		public static SceneID Creep = new SceneID("41C7E68BB7EDBCB6BE2E4B16B5ABF194") {
			Children = new List<SceneID>() { new SceneID("40E0B0198E3B4DC02472B6D707F76392"),
											 new SceneID("4F1B1CD7CF1D731D5ED4A52AA57A849B"),
											 new SceneID("4F9299518C31878C6EF0EE78DCA97AAD"),
											 new SceneID("47AD56F2FC363735615E5ED3D22C0283") }
		};
		public static SceneID StompableFloor1 = new SceneID("4892C34A3FEAF90428B089547C3EB8B0");
		public static SceneID StompableFloor2 = new SceneID("4B3E88C15463F9D540730049984DC49C");
		public static SceneID StompableFloor3 = new SceneID("44B4ECEB586F0A0385601F7F002D0AB3");
	}
	public class ValleyOfTheWindGetChargeJump : SceneID {
		public static SceneID RedBulb1 = new SceneID("4D96979500A7CACA9CF75A2D06CFEAA5");
		public static SceneID RedBulb2 = new SceneID("4729A16E4F16252A93D61526D938E3B4");
		public static SceneID RedBulb3 = new SceneID("422AFB6E60F689E5EB4BE0638BE805BE");
		public static SceneID RedBulb4 = new SceneID("43A44B7FD638DB7A701F424E80FCB0B3");
		public static SceneID RedBulb5 = new SceneID("4244834DCF560AFAA24A1DFFCEDE2EA9");
		public static SceneID AbilityCell = new SceneID("4357AD0B8196635E2D25F6E37CBC2395");
		public static SceneID StompableFloor1 = new SceneID("401F3DBABEEB7866189E854AAAE5299D");
		public static SceneID StompableFloor2 = new SceneID("4050DB8A0F8FE5844358011D7540DDAD");
		public static SceneID StompableFloor3 = new SceneID("4180BB3C6E295028BF5B86BB599B8DA7");
	}
	public class ValleyOfTheWindHubIceLaserB : SceneID {
		public static SceneID Keystone = new SceneID("4ABD026227E72095FAF76754CC6B8283");
		public static SceneID StompableFloor1 = new SceneID("416103D6ABB2F1E8C088AA8A5AF80182");
		public static SceneID StompableFloor2 = new SceneID("428A6DC3269E4544A996A9546900CE84");
	}
	public class ValleyOfTheWindHubL : SceneID {
		public static SceneID DoorWithFourSlots = new SceneID("4573055875AAC1EF083603EF0721D1BA");
		public static SceneID StompableFloor1 = new SceneID("4B4F739F6086461290B6176E197E539E");
		public static SceneID StompableFloor2 = new SceneID("4E87315D6761C070BC1D3DCCE94868A1");
	}
	public class ValleyOfTheWindHubR : SceneID {
		public static SceneID EnergyDoorFourSlots = new SceneID("4D36CEFFE027D65BAA571CDE352EC097");
		public static SceneID Keystone1 = new SceneID("4AE80FF308AEA3889EEB9689610F80BA");
		public static SceneID Keystone2 = new SceneID("4A8A2F6120B4843476CC28E71A8D30B4");
		public static SceneID StompableFloor = new SceneID("41770942A21E73629C6015E64E7139BA");
	}
	public class ValleyOfTheWindIcePuzzle : SceneID {
		public static SceneID HealthCell = new SceneID("41A5F6CCECA081C3D4BD682F90BE5E81");
		public static SceneID Keystone = new SceneID("4BA4EF5130BE7EF8CD8435B2B59C1BB0");
		public static SceneID ExpOrb200 = new SceneID("404910483B9AD6C089C5DBD18598AEB2");
		public static SceneID AbilityCell = new SceneID("4BD622C9D5966D58FDAD90B3B5D4B49E");
		public static SceneID PetrifiedPlant = new SceneID("499640255358D7E38405256165923A98");
		public static SceneID StompableFloor1 = new SceneID("46B3D9D4BF34736FC168398FE7CAAE9C");
		public static SceneID StompableFloor2 = new SceneID("4CAAC05BFE56735191CDA3632A38498C");
		public static SceneID SpiritTorch = new SceneID("4808EAF182AA07328708ADEAC1C502AC") {
			Children = new List<SceneID>() { new SceneID("43DA6966C292C63BDFB2DDB337B6A8A9") { Name = "Animator" },
											 new SceneID("4D25D1B24A083466B1AFA38394776492") { Name = "Activator" },
											 new SceneID("462954853E0F6C4180C594E34A105883") }
		};
	}
	public class ValleyOfTheWindLaserShaft : SceneID {
		public static SceneID DoorWithFourSlots = new SceneID("4BEB1F1C57C884E210B499F824BFD4AD");
		public static SceneID Keystone1 = new SceneID("4CEDAEC6C028B0DCE220A307DD21DA80");
		public static SceneID Keystone2 = new SceneID("4012C4C3BC7A14BA736E67E8CC801E96");
		public static SceneID Keystone3 = new SceneID("4C3334181834D53844AA846615BC1BB2");
		public static SceneID Keystone4 = new SceneID("49CCEA241F06E2E96F60A527ECF78C88");
		public static SceneID EnergyCell = new SceneID("489771BF596CEC123644A80FA3086AB0");
	}
	public class ValleyOfTheWindShaft : SceneID {
		public static SceneID StompablePlatform = new SceneID("4FD6402E7747D97382B3127793A6F78B");
	}
	public class ValleyOfTheWindTop : SceneID {
		public static SceneID SunStoneSetup_storySetups_Trigger = new SceneID("4E3FA0F12652254EBD7D07556C2E598D");
		public static SceneID SunStoneSetup_key_Trigger = new SceneID("46FB78656BF90C1E475039833CAEF5BD");
		public static SceneID AirbornEasteregg_Trigger = new SceneID("4C9324825740700948FBA40E3606E992");
		public static SceneID PetrifiedPlant = new SceneID("4A32D156472A7E7916F349A3C2941494");
		public static SceneID SeinAbilityRestrictZone = new SceneID("428B3603BC19EC731AA4D82BCF290C93");
	}
	public class ValleyOfTheWindWideLeft : SceneID {
		public static SceneID DoorWithFourSlots = new SceneID("455E2F358E27DC22597326CA6EC15891");
		public static SceneID Keystone = new SceneID("431F353DA11D0365E4FA90C5D51CF3B1");
		public static SceneID ExpOrb100 = new SceneID("485EE1D8C80CB4B5F9249AC34C226C9D");
	}
	public class ValleyOfTheWindWideMid : SceneID {
		public static SceneID Keystone1 = new SceneID("49124F593D197976788DCD28F07F5D98");
		public static SceneID Keystone2 = new SceneID("4D12E69D08C894761AB5979CFCE80ABF");
		public static SceneID StompableFloor = new SceneID("4F970A1E3EAED13C57D050A1ACBA8DBC");
	}
	public class ValleyOfTheWindWideRight : SceneID {
		public static SceneID Keystone = new SceneID("4C9DB21366770AC81B6C76CF2842D495");
	}
	public class WestGladesBashCave : SceneID {
		public static SceneID ExpOrb100 = new SceneID("4B1CE9ADD140DD7E2DF173913BE0DCB3");
	}
	public class WestGladesCliffsC : SceneID {
		public static SceneID ExpOrb100 = new SceneID("42A203627B9C9BD34712BB581A2AD799");
		public static SceneID AbilityCell = new SceneID("4055F33347674B4DC0C86E6DACAAB7AE");
	}
	public class WestGladesFireflyAreaA : SceneID {
		public static SceneID AbilityCell = new SceneID("403DA9A46B9BEC410D5B4A5D502A6DBA");
	}
	public class WestGladesOverworldForestA : SceneID {
		public static SceneID AbilityCell = new SceneID("47F09A1A943D1E3C4CB5EAC0EC2B80AB");
		public static SceneID ExpOrb100 = new SceneID("421D22BC4422FD5A28E6BDB1A95DE287");
		public static SceneID PetrifiedPlant = new SceneID("4552C7FDC2F07721EFEAC56DD954B08E");
		public static SceneID StompableFloor = new SceneID("4E350923F9E82E4B18635BD62153FC97");
		public static SceneID SpiritTorch = new SceneID("458EBE133957C5CDEDF131EEC479C7B6") {
			Children = new List<SceneID>() { new SceneID("47467843CB3E8745808401AAFE0D4882") { Name = "Animator" },
											 new SceneID("4A9D68F248E63636660C357B84D7A5AD") { Name = "Activator" },
											 new SceneID("40EDCA2B3E7D2B00AD6EFC59C07CA1A3") }
		};
	}
	public class WestGladesRollingSootIntroduction : SceneID {
		public static SceneID Wall1 = new SceneID("473DE2B5BD5ACC5EDE709BE3C8D3688A");
		public static SceneID Wall2 = new SceneID("405CA9D973CC8D0BA38263CB89BDCA85");
		public static SceneID Wall3 = new SceneID("4F0569E875222C59772F199A41502CB0");
		public static SceneID Mapstone = new SceneID("40E7C38FA4D03B35991EC746B24B7E83");
		public static SceneID AbilityCell = new SceneID("42C0FC641D28A90DE733A9667EA5A7B9");
		public static SceneID SpiritTorch = new SceneID("408F8AFE27AE03FEEB84D987AB3F74B0") {
			Children = new List<SceneID>() { new SceneID("4445C5E32320288DFC36BE0371F2D883") { Name = "Animator" },
											 new SceneID("458BE7A3E8597B5D3CE72987297A50AE") { Name = "Activator" },
											 new SceneID("4D49D2B2FB6432781E6B38CEE0126CBA") }
		};
	}
	public class WestGladesSorrowEntranceAB : SceneID {
		public static SceneID AbilityCell = new SceneID("4A64D41817EC14A86D4098A9F8079695");
		public static SceneID StompableFloor1 = new SceneID("46055F15087D717B6BF3F32663BFFDB3");
		public static SceneID StompableFloor2 = new SceneID("47568B339962A16E55F0DFED99669C95");
		public static SceneID StompablePlatform = new SceneID("4046F6B5B01D187CEC5D2E04B7187D88");
	}
	public class WestGladesTIntersectionB : SceneID {
		public static SceneID Wall = new SceneID("46AC6CD2D75C2B1462D20312DC790084");
		public static SceneID AbilityCell = new SceneID("4CAA16EBC422986FA87018CCBDFD7786");
	}
	public class WestGladesWaterStomp : SceneID {
		public static SceneID EnergyCell = new SceneID("40686D854A745D02856F30FBD4D4D8BF");
	}
}
USE [zaren_test]
GO
/****** Object:  Table [dbo].[Accommodation]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accommodation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PNRId] [int] NULL,
	[AccommodationCheckIN] [date] NULL,
	[AccommodationCheckOUT] [date] NULL,
	[HotelId] [int] NULL,
	[RoTyId] [int] NULL,
	[AccommodationRate] [decimal](18, 0) NULL,
	[CurrencyId] [int] NULL,
	[BrokerId] [int] NULL,
	[AccommodationBookedDate] [datetime] NULL,
	[AccommodationTimestap] [datetime] NULL,
	[AccommodationActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccommodationExtras]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccommodationExtras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccommodationId] [int] NULL,
	[ExTyId] [int] NULL,
	[AcExDescription] [nvarchar](50) NULL,
	[AcExFare] [int] NULL,
	[AcExTimestamp] [datetime] NULL,
	[AcExActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agency]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgencyIATA] [int] NULL,
	[AgencyCode] [nvarchar](10) NULL,
	[AgencyName] [nvarchar](1) NULL,
	[AgencyRepresentative] [nvarchar](1) NULL,
	[AgGrId] [int] NULL,
	[CountryId] [int] NULL,
	[LanguagesId] [int] NULL,
	[AgencyTimestamp] [int] NULL,
	[AgencyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgencyGroup]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencyGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgGrName] [nvarchar](40) NULL,
	[AgGrTimestamp] [datetime] NULL,
	[AgGrActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgentInformation]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgentInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgentCode] [varchar](50) NOT NULL,
	[AgentName] [varchar](500) NULL,
	[AgentStation] [varchar](50) NULL,
	[FILE_ID] [int] NULL,
	[FILE_NAME] [varchar](255) NULL,
	[RecordDateStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[AgentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Air]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Air](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirlineId] [int] NULL,
	[AirRecordAirline] [nvarchar](7) NULL,
	[AirTicket] [nvarchar](13) NULL,
	[AirBookedDate] [datetime] NULL,
	[AirIssueddate] [datetime] NULL,
	[AirReIssued] [bit] NULL,
	[AirOriginalTicket] [nvarchar](13) NULL,
	[PNRId] [int] NULL,
	[CurrencyId] [int] NULL,
	[AirFare] [decimal](18, 0) NULL,
	[AirTax] [decimal](18, 0) NULL,
	[AirLowestFare] [decimal](18, 0) NULL,
	[AirHighestFare] [decimal](18, 0) NULL,
	[AirFareBases] [nvarchar](40) NULL,
	[BrokerId] [int] NULL,
	[AirIncludeBags] [bit] NULL,
	[AirTimestamp] [datetime] NULL,
	[AirActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirExtras]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirExtras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirId] [int] NULL,
	[ExTyId] [int] NULL,
	[AiExDescription] [nvarchar](50) NULL,
	[AiExFare] [decimal](18, 0) NULL,
	[AiExTimestamp] [datetime] NULL,
	[AiExActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airline]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airline](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirlineCode] [nvarchar](2) NULL,
	[AirlineName] [nvarchar](50) NULL,
	[AirlinePlate] [char](3) NULL,
	[AirlineTimestamp] [datetime] NULL,
	[AirlineActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airport]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirportCode] [char](3) NULL,
	[AirportName] [nvarchar](40) NULL,
	[CountryId] [int] NULL,
	[CityId] [int] NULL,
	[AirportTimestamp] [datetime] NULL,
	[AirportActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirSegments]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirSegments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirId] [int] NULL,
	[AirlineId] [int] NULL,
	[AiSeDeparture] [datetime] NULL,
	[AiSeArrival] [datetime] NULL,
	[AirportIdOrigin] [int] NULL,
	[AirportIdDestination] [int] NULL,
	[AiSeFlightNumber] [char](4) NULL,
	[AiSeClass] [bit] NULL,
	[TerminalIdOrigin] [int] NULL,
	[TerminalIdDestination] [int] NULL,
	[AiSeTimestamp] [datetime] NULL,
	[AiSeActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Broker]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Broker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrokerCode] [nvarchar](10) NULL,
	[BrokerName] [nvarchar](50) NULL,
	[BrokerTimestamp] [datetime] NULL,
	[BrokerActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carrent]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carrent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PNRId] [int] NULL,
	[CaTyId] [int] NULL,
	[CaRtId] [int] NULL,
	[AirportIdPickUp] [int] NULL,
	[AirportIdReturn] [int] NULL,
	[CaRePickUpDate] [datetime] NULL,
	[CaReReturnDate] [datetime] NULL,
	[CaReRate] [decimal](18, 0) NULL,
	[CaReTax] [decimal](18, 0) NULL,
	[CurrencyId] [int] NULL,
	[CaReBookDate] [datetime] NULL,
	[CaReTimestamp] [datetime] NULL,
	[CaReActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarRental]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarRental](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CaRtCode] [nvarchar](10) NULL,
	[CaRtName] [nvarchar](1) NULL,
	[CaRtTimestamp] [datetime] NULL,
	[CaRtActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CaTyCode] [nvarchar](10) NULL,
	[CaTyDescription] [nvarchar](1) NULL,
	[CaTyTimestamp] [datetime] NULL,
	[CaTyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chain]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chain](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChainCode] [char](2) NULL,
	[ChainName] [nvarchar](50) NULL,
	[ChainTimestamp] [datetime] NULL,
	[ChainActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityCode] [char](3) NULL,
	[CityName] [nvarchar](50) NULL,
	[CountryId] [int] NULL,
	[CityTimestamp] [datetime] NULL,
	[CityActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [nvarchar](20) NULL,
	[AgencyId] [int] NULL,
	[CountryId] [int] NULL,
	[CompanyRepresentative] [nvarchar](40) NULL,
	[CoGrId] [int] NULL,
	[CoDiId] [int] NULL,
	[LanguagesId] [int] NULL,
	[CurrencyId] [int] NULL,
	[InSeId] [int] NULL,
	[CompanyTimestamp] [datetime] NULL,
	[CompanyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyCustomFields]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyCustomFields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[CoCuCode] [nvarchar](30) NULL,
	[FiTyId] [int] NULL,
	[CoCuTimestamp] [datetime] NULL,
	[CoCuActive] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyDivisions]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyDivisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoDiName] [nvarchar](40) NULL,
	[CoDiCode] [nvarchar](20) NULL,
	[CoDiTimestamp] [datetime] NULL,
	[CoDiActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyGroup]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CoGrName] [nvarchar](40) NULL,
	[CoGrTravelManager] [nvarchar](40) NULL,
	[CoGrTimestamp] [int] NULL,
	[CoGrActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [char](2) NULL,
	[CountryName] [nvarchar](40) NULL,
	[CurrencyId] [int] NULL,
	[CountryTimestamp] [datetime] NULL,
	[CountryActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [nvarchar](5) NULL,
	[CurrencyCodeIata] [char](3) NULL,
	[CurrencyName] [nvarchar](40) NULL,
	[CurrencyTimestamp] [datetime] NULL,
	[CurrencyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerInformation]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmailId] [varchar](255) NULL,
	[Title] [varchar](50) NULL,
	[FirstName] [varchar](500) NULL,
	[LastName] [varchar](500) NULL,
	[Gender] [varchar](50) NULL,
	[AlternativeEmailId] [varchar](255) NULL,
	[Telephone] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[CountryCode] [varchar](50) NULL,
	[LanguageCode] [varchar](50) NULL,
	[OfficeTelephone] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Fax] [varchar](50) NULL,
	[NationalityCode] [int] NULL,
	[AgentCode] [varchar](50) NULL,
	[CustomerId_N] [int] NULL,
	[Totalpaxcount] [decimal](18, 0) NULL,
	[TotalInfantcount] [decimal](18, 0) NULL,
	[TotalFare] [decimal](18, 0) NULL,
	[TotalTaxChg] [decimal](18, 0) NULL,
	[BookingStatus] [int] NULL,
	[ModificationDate] [datetime] NULL,
	[FILE_ID] [int] NULL,
	[FILE_NAME] [varchar](255) NULL,
	[RecordDateStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeRates]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyIdFrom] [int] NULL,
	[CurrencyIdTo] [int] NULL,
	[ExRaValue] [decimal](18, 0) NULL,
	[ExRaDate] [date] NULL,
	[ExRaTimestamp] [int] NULL,
	[ExRaActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExtrasType]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtrasType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExTyCode] [nvarchar](10) NULL,
	[ExTyName] [nvarchar](50) NULL,
	[ExTyTimestamp] [datetime] NULL,
	[ExTyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FieldsType]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldsType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FiTyCode] [nvarchar](10) NULL,
	[FiTyName] [nvarchar](30) NULL,
	[FiTyTimestamp] [datetime] NULL,
	[FiTyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GDS]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GDSName] [nvarchar](40) NULL,
	[GDSTimestamp] [datetime] NULL,
	[GDSActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](50) NULL,
	[CityId] [int] NULL,
	[ChainId] [int] NULL,
	[HotelTimestamp] [datetime] NULL,
	[HotelActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelCodes]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelId] [int] NULL,
	[BrokerId] [int] NULL,
	[HoCoCode] [nvarchar](10) NULL,
	[HoCoTimestamp] [datetime] NULL,
	[HoCoActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IndustrySegment]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndustrySegment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InSeDescription] [nvarchar](50) NULL,
	[InSeTimestamp] [datetime] NULL,
	[InSeActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguagesName] [nvarchar](50) NULL,
	[LanguagesCode] [char](2) NULL,
	[LanguagesTimestamp] [date] NULL,
	[LanguagesActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PassengerFullName] [nvarchar](50) NULL,
	[PassengerPhone] [nvarchar](15) NULL,
	[PassengerCelPhone] [nvarchar](15) NULL,
	[PassengerEmail] [nvarchar](50) NULL,
	[PassengerJobPosition] [nvarchar](40) NULL,
	[PassengerVIP] [bit] NULL,
	[PassemgerTimestamp] [datetime] NULL,
	[PassengerActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassengerInformation]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassengerInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PnrpaxId] [varchar](50) NULL,
	[Pnr] [varchar](50) NOT NULL,
	[PaxSequence] [int] NULL,
	[Title] [varchar](50) NULL,
	[FirstName] [varchar](500) NULL,
	[LastName] [varchar](500) NULL,
	[AdultId] [int] NULL,
	[NationalityCode] [int] NULL,
	[TotalFare] [decimal](18, 0) NULL,
	[TotalTaxchg] [decimal](18, 0) NULL,
	[TotalPaid] [decimal](18, 0) NULL,
	[FILE_ID] [int] NULL,
	[FILE_NAME] [varchar](255) NULL,
	[RecordDateStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Pnr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PCC]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PCC](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PCCCode] [nvarchar](10) NULL,
	[PCCIata] [int] NULL,
	[AgencyId] [int] NULL,
	[GDSId] [int] NULL,
	[PCCTimestamp] [datetime] NULL,
	[PCCActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNR]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PNR](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgencyId] [int] NULL,
	[PCCId] [int] NULL,
	[CompanyId] [int] NULL,
	[PassengerId] [int] NULL,
	[PNRRecord] [nvarchar](7) NULL,
	[PNRTimestamp] [datetime] NULL,
	[PNRActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PNRCustomFields]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PNRCustomFields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FiTyId] [int] NULL,
	[PNRId] [int] NULL,
	[PnCuValue] [nvarchar](50) NULL,
	[FiTyTimestamp] [datetime] NULL,
	[FiTyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationInformation]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PNR] [varchar](50) NULL,
	[BookingTimeStamp] [datetime] NULL,
	[FirstName] [varchar](500) NULL,
	[LastName] [varchar](500) NULL,
	[PassportNumber] [varchar](50) NULL,
	[StreetAddress1] [varchar](500) NULL,
	[StreetAddress2] [varchar](500) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[CountryCode] [varchar](50) NULL,
	[PhoneNo] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](255) NULL,
	[NationalityCode] [int] NULL,
	[SalesChannelCode] [int] NULL,
	[AgentCode] [varchar](50) NULL,
	[CustomerId] [int] NULL,
	[Totalpaxcount] [int] NULL,
	[TotalInfantcount] [int] NULL,
	[TotalTaxChg] [decimal](18, 0) NULL,
	[TotalFare] [decimal](18, 0) NULL,
	[BookingStatus] [varchar](50) NULL,
	[ModificationDate] [datetime] NULL,
	[FILE_ID] [int] NULL,
	[FILE_NAME] [varchar](255) NULL,
	[RecordDateStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoTyCode] [nvarchar](10) NULL,
	[RoTyDescription] [nvarchar](50) NULL,
	[RoTyTimestamp] [datetime] NULL,
	[RoTyActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SegmentInformation]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SegmentInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PNRSegId] [varchar](50) NULL,
	[PNR] [varchar](50) NULL,
	[FlightNumber] [varchar](50) NULL,
	[Origin] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Segmentcode] [varchar](50) NULL,
	[EsttimeDepartureLocal] [datetime] NULL,
	[EsttimeArrivalLocal] [datetime] NULL,
	[Daynumber] [int] NULL,
	[SegmentStatus] [varchar](50) NULL,
	[ModificationDate] [datetime] NULL,
	[FILE_ID] [int] NULL,
	[FILE_NAME] [varchar](255) NULL,
	[RecordDateStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Terminal]    Script Date: 29.12.2022 18:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Terminal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TerminalName] [nvarchar](50) NULL,
	[TerminalCode] [nvarchar](20) NULL,
	[AirportId] [int] NULL,
	[TerminalTimestamp] [datetime] NULL,
	[TerminalActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AgentInformation] ADD  DEFAULT (NULL) FOR [AgentCode]
GO
ALTER TABLE [dbo].[AgentInformation] ADD  DEFAULT (NULL) FOR [AgentName]
GO
ALTER TABLE [dbo].[AgentInformation] ADD  DEFAULT (NULL) FOR [AgentStation]
GO
ALTER TABLE [dbo].[AgentInformation] ADD  DEFAULT (NULL) FOR [FILE_ID]
GO
ALTER TABLE [dbo].[AgentInformation] ADD  DEFAULT (NULL) FOR [FILE_NAME]
GO
ALTER TABLE [dbo].[AgentInformation] ADD  DEFAULT ('getdate()') FOR [RecordDateStamp]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [CustomerId]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [EmailId]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [Title]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [FirstName]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [LastName]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [Gender]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [AlternativeEmailId]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [Telephone]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [Mobile]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [CountryCode]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [LanguageCode]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [OfficeTelephone]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [DateOfBirth]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [Fax]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [NationalityCode]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [AgentCode]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [CustomerId_N]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [Totalpaxcount]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [TotalInfantcount]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [TotalFare]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [TotalTaxChg]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [BookingStatus]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [ModificationDate]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [FILE_ID]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [FILE_NAME]
GO
ALTER TABLE [dbo].[CustomerInformation] ADD  DEFAULT (NULL) FOR [RecordDateStamp]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [PnrpaxId]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [Pnr]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [PaxSequence]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [Title]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [FirstName]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [LastName]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [AdultId]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [NationalityCode]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [TotalFare]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [TotalTaxchg]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [TotalPaid]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [FILE_ID]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT (NULL) FOR [FILE_NAME]
GO
ALTER TABLE [dbo].[PassengerInformation] ADD  DEFAULT ('getdate()') FOR [RecordDateStamp]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [PNR]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [BookingTimeStamp]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [FirstName]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [LastName]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [PassportNumber]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [StreetAddress1]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [StreetAddress2]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [City]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [State]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [CountryCode]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [PhoneNo]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [MobileNo]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [Fax]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [Email]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [NationalityCode]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [SalesChannelCode]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [AgentCode]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [CustomerId]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [Totalpaxcount]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [TotalInfantcount]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [TotalTaxChg]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [TotalFare]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [BookingStatus]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [ModificationDate]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [FILE_ID]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT (NULL) FOR [FILE_NAME]
GO
ALTER TABLE [dbo].[ReservationInformation] ADD  DEFAULT ('getdate()') FOR [RecordDateStamp]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [PNRSegId]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [PNR]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [FlightNumber]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [Origin]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [Destination]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [Segmentcode]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [EsttimeDepartureLocal]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [EsttimeArrivalLocal]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [Daynumber]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [SegmentStatus]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [ModificationDate]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [FILE_ID]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [FILE_NAME]
GO
ALTER TABLE [dbo].[SegmentInformation] ADD  DEFAULT (NULL) FOR [RecordDateStamp]
GO
ALTER TABLE [dbo].[Accommodation]  WITH CHECK ADD FOREIGN KEY([BrokerId])
REFERENCES [dbo].[Broker] ([Id])
GO
ALTER TABLE [dbo].[Accommodation]  WITH CHECK ADD FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Accommodation]  WITH CHECK ADD FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
GO
ALTER TABLE [dbo].[Accommodation]  WITH CHECK ADD FOREIGN KEY([PNRId])
REFERENCES [dbo].[PNR] ([Id])
GO
ALTER TABLE [dbo].[Accommodation]  WITH CHECK ADD FOREIGN KEY([RoTyId])
REFERENCES [dbo].[RoomType] ([Id])
GO
ALTER TABLE [dbo].[AccommodationExtras]  WITH CHECK ADD FOREIGN KEY([AccommodationId])
REFERENCES [dbo].[Accommodation] ([Id])
GO
ALTER TABLE [dbo].[AccommodationExtras]  WITH CHECK ADD FOREIGN KEY([ExTyId])
REFERENCES [dbo].[ExtrasType] ([Id])
GO
ALTER TABLE [dbo].[Agency]  WITH CHECK ADD FOREIGN KEY([AgGrId])
REFERENCES [dbo].[AgencyGroup] ([Id])
GO
ALTER TABLE [dbo].[Agency]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Agency]  WITH CHECK ADD FOREIGN KEY([LanguagesId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Air]  WITH CHECK ADD FOREIGN KEY([AirlineId])
REFERENCES [dbo].[Airline] ([Id])
GO
ALTER TABLE [dbo].[Air]  WITH CHECK ADD FOREIGN KEY([BrokerId])
REFERENCES [dbo].[Broker] ([Id])
GO
ALTER TABLE [dbo].[Air]  WITH CHECK ADD FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Air]  WITH CHECK ADD FOREIGN KEY([PNRId])
REFERENCES [dbo].[PNR] ([Id])
GO
ALTER TABLE [dbo].[AirExtras]  WITH CHECK ADD FOREIGN KEY([AirId])
REFERENCES [dbo].[Air] ([Id])
GO
ALTER TABLE [dbo].[AirExtras]  WITH CHECK ADD FOREIGN KEY([ExTyId])
REFERENCES [dbo].[ExtrasType] ([Id])
GO
ALTER TABLE [dbo].[Airport]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Airport]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[AirSegments]  WITH CHECK ADD FOREIGN KEY([AirId])
REFERENCES [dbo].[Air] ([Id])
GO
ALTER TABLE [dbo].[AirSegments]  WITH CHECK ADD FOREIGN KEY([AirlineId])
REFERENCES [dbo].[Airline] ([Id])
GO
ALTER TABLE [dbo].[AirSegments]  WITH CHECK ADD FOREIGN KEY([AirportIdOrigin])
REFERENCES [dbo].[Airport] ([Id])
GO
ALTER TABLE [dbo].[AirSegments]  WITH CHECK ADD FOREIGN KEY([AirportIdDestination])
REFERENCES [dbo].[Airport] ([Id])
GO
ALTER TABLE [dbo].[AirSegments]  WITH CHECK ADD FOREIGN KEY([TerminalIdOrigin])
REFERENCES [dbo].[Terminal] ([Id])
GO
ALTER TABLE [dbo].[AirSegments]  WITH CHECK ADD FOREIGN KEY([TerminalIdDestination])
REFERENCES [dbo].[Terminal] ([Id])
GO
ALTER TABLE [dbo].[carrent]  WITH CHECK ADD FOREIGN KEY([AirportIdPickUp])
REFERENCES [dbo].[Airport] ([Id])
GO
ALTER TABLE [dbo].[carrent]  WITH CHECK ADD FOREIGN KEY([AirportIdReturn])
REFERENCES [dbo].[Airport] ([Id])
GO
ALTER TABLE [dbo].[carrent]  WITH CHECK ADD FOREIGN KEY([CaRtId])
REFERENCES [dbo].[CarRental] ([Id])
GO
ALTER TABLE [dbo].[carrent]  WITH CHECK ADD FOREIGN KEY([CaTyId])
REFERENCES [dbo].[CarType] ([Id])
GO
ALTER TABLE [dbo].[carrent]  WITH CHECK ADD FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[carrent]  WITH CHECK ADD FOREIGN KEY([PNRId])
REFERENCES [dbo].[PNR] ([Id])
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([CoDiId])
REFERENCES [dbo].[CompanyDivisions] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([CoGrId])
REFERENCES [dbo].[CompanyGroup] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([InSeId])
REFERENCES [dbo].[IndustrySegment] ([Id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([LanguagesId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[CompanyCustomFields]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[CompanyCustomFields]  WITH CHECK ADD FOREIGN KEY([FiTyId])
REFERENCES [dbo].[FieldsType] ([Id])
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD FOREIGN KEY([CurrencyIdFrom])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD FOREIGN KEY([CurrencyIdTo])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD FOREIGN KEY([ChainId])
REFERENCES [dbo].[Chain] ([Id])
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[HotelCodes]  WITH CHECK ADD FOREIGN KEY([BrokerId])
REFERENCES [dbo].[Broker] ([Id])
GO
ALTER TABLE [dbo].[HotelCodes]  WITH CHECK ADD FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
GO
ALTER TABLE [dbo].[PCC]  WITH CHECK ADD FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([Id])
GO
ALTER TABLE [dbo].[PCC]  WITH CHECK ADD FOREIGN KEY([GDSId])
REFERENCES [dbo].[GDS] ([Id])
GO
ALTER TABLE [dbo].[PNR]  WITH CHECK ADD FOREIGN KEY([AgencyId])
REFERENCES [dbo].[Agency] ([Id])
GO
ALTER TABLE [dbo].[PNR]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[PNR]  WITH CHECK ADD FOREIGN KEY([PassengerId])
REFERENCES [dbo].[Passenger] ([Id])
GO
ALTER TABLE [dbo].[PNR]  WITH CHECK ADD FOREIGN KEY([PCCId])
REFERENCES [dbo].[PCC] ([Id])
GO
ALTER TABLE [dbo].[PNRCustomFields]  WITH CHECK ADD FOREIGN KEY([FiTyId])
REFERENCES [dbo].[FieldsType] ([Id])
GO
ALTER TABLE [dbo].[PNRCustomFields]  WITH CHECK ADD FOREIGN KEY([PNRId])
REFERENCES [dbo].[PNR] ([Id])
GO
ALTER TABLE [dbo].[Terminal]  WITH CHECK ADD FOREIGN KEY([AirportId])
REFERENCES [dbo].[Airport] ([Id])
GO

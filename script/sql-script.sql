/****** Object:  Table [dbo].[T_TEMPLATE]    Script Date: 11/22/2012 23:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_TEMPLATE](
	[ct_record_no] [int] IDENTITY(1,1) NOT NULL,
	[id_template_key] [int] NOT NULL,
	[tx_template_name] [varchar](32) NOT NULL,
	[tx_note] [varchar](250) NULL,
	[dtt_mod] [datetime] NOT NULL,
	[is_active] [bit] NOT NULL,
	[dt_time_stamp] [timestamp] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_TEMPLATE] ON
INSERT [dbo].[T_TEMPLATE] ([ct_record_no], [id_template_key], [tx_template_name], [tx_note], [dtt_mod], [is_active]) VALUES (1, 8810001, N'My  Template - 1', N'I will not say I have failed 1000 times; I will say that I have discovered 1000 ways that can cause failure – Thomas Edison', CAST(0x0000A11100000000 AS DateTime), 1)
INSERT [dbo].[T_TEMPLATE] ([ct_record_no], [id_template_key], [tx_template_name], [tx_note], [dtt_mod], [is_active]) VALUES (2, 8810002, N'My  Template - 2', N'I will not say I have failed 1000 times; I will say that I have discovered 1000 ways that can cause failure – Thomas Edison', CAST(0x0000A11100000000 AS DateTime), 1)
INSERT [dbo].[T_TEMPLATE] ([ct_record_no], [id_template_key], [tx_template_name], [tx_note], [dtt_mod], [is_active]) VALUES (3, 8810003, N'My  Template - 3', N'I will not say I have failed 1000 times; I will say that I have discovered 1000 ways that can cause failure – Thomas Edison', CAST(0x0000A11100000000 AS DateTime), 1)
INSERT [dbo].[T_TEMPLATE] ([ct_record_no], [id_template_key], [tx_template_name], [tx_note], [dtt_mod], [is_active]) VALUES (4, 8810004, N'My  Template - 4', N'I will not say I have failed 1000 times; I will say that I have discovered 1000 ways that can cause failure – Thomas Edison', CAST(0x0000A11100000000 AS DateTime), 1)
INSERT [dbo].[T_TEMPLATE] ([ct_record_no], [id_template_key], [tx_template_name], [tx_note], [dtt_mod], [is_active]) VALUES (5, 8810005, N'My  Template - 5', N'I will not say I have failed 1000 times; I will say that I have discovered 1000 ways that can cause failure – Thomas Edison', CAST(0x0000A11100000000 AS DateTime), 1)
INSERT [dbo].[T_TEMPLATE] ([ct_record_no], [id_template_key], [tx_template_name], [tx_note], [dtt_mod], [is_active]) VALUES (6, 8810006, N'My  Template - 6', N'I will not say I have failed 1000 times; I will say that I have discovered 1000 ways that can cause failure – Thomas Edison', CAST(0x0000A11100000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[T_TEMPLATE] OFF
/****** Object:  Table [dbo].[T_SYSTEM_KEY]    Script Date: 11/22/2012 23:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_SYSTEM_KEY](
	[id_sys_rec_no] [int] IDENTITY(1,1) NOT NULL,
	[id_sys_key] [varchar](36) NULL,
	[tx_key_name] [varchar](32) NOT NULL,
	[is_active] [bit] NOT NULL,
	[id_ds_env_key] [int] NOT NULL,
	[dtt_mod] [datetime] NOT NULL,
	[id_user_mod] [int] NOT NULL,
	[id_key_value] [int] NOT NULL,
	[tx_table_name] [varchar](32) NOT NULL,
	[tx_sys_key_version] [int] NULL,
	[tx_desc] [varchar](256) NOT NULL,
	[dt_time_stamp] [timestamp] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_SYSTEM_KEY] ON
INSERT [dbo].[T_SYSTEM_KEY] ([id_sys_rec_no], [id_sys_key], [tx_key_name], [is_active], [id_ds_env_key], [dtt_mod], [id_user_mod], [id_key_value], [tx_table_name], [tx_sys_key_version], [tx_desc]) VALUES (1, N'1', N'id_template_key', 1, 8810000, CAST(0x0000A05800000000 AS DateTime), 0, 8810006, N'T_TEMPLATE', 0, N'id_template_key')
SET IDENTITY_INSERT [dbo].[T_SYSTEM_KEY] OFF
/****** Object:  Table [dbo].[T_NULL_VALUES]    Script Date: 11/22/2012 23:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_NULL_VALUES](
	[id_null_key] [int] NOT NULL,
	[id_null_ver] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[id_ds_rgn] [int] NOT NULL,
	[id_usr_mod] [int] NOT NULL,
	[dt_mod] [datetime] NOT NULL,
	[tx_null_value_name] [varchar](30) NOT NULL,
	[tx_null_value] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[T_NULL_VALUES] ([id_null_key], [id_null_ver], [is_active], [id_ds_rgn], [id_usr_mod], [dt_mod], [tx_null_value_name], [tx_null_value]) VALUES (1, 0, 1, 100, 1, CAST(0x00009CA60142146D AS DateTime), N'DB_NULL_INT', N'-2147483648')
INSERT [dbo].[T_NULL_VALUES] ([id_null_key], [id_null_ver], [is_active], [id_ds_rgn], [id_usr_mod], [dt_mod], [tx_null_value_name], [tx_null_value]) VALUES (2, 0, 1, 100, 1, CAST(0x00009CA60142146D AS DateTime), N'DB_NULL_STRING', N'?')
INSERT [dbo].[T_NULL_VALUES] ([id_null_key], [id_null_ver], [is_active], [id_ds_rgn], [id_usr_mod], [dt_mod], [tx_null_value_name], [tx_null_value]) VALUES (3, 0, 1, 100, 1, CAST(0x00009CA60142146D AS DateTime), N'DB_NULL_CHAR', N'?')
INSERT [dbo].[T_NULL_VALUES] ([id_null_key], [id_null_ver], [is_active], [id_ds_rgn], [id_usr_mod], [dt_mod], [tx_null_value_name], [tx_null_value]) VALUES (4, 0, 1, 100, 1, CAST(0x00009CA60142146D AS DateTime), N'DB_NULL_DATE', N'01/01/1970')
/****** Object:  Table [dbo].[T_DATA_SERVER]    Script Date: 11/22/2012 23:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_DATA_SERVER](
	[id_ds_env_key] [int] NOT NULL,
	[id_ds_env_ver] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[dtt_mod] [datetime] NOT NULL,
	[id_user_mod] [int] NOT NULL,
	[tx_ds_name] [varchar](32) NOT NULL,
	[tx_env_name] [varchar](32) NOT NULL,
	[tx_desc] [varchar](256) NOT NULL,
	[ct_gmt_offset_mins] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[T_DATA_SERVER] ([id_ds_env_key], [id_ds_env_ver], [is_active], [dtt_mod], [id_user_mod], [tx_ds_name], [tx_env_name], [tx_desc], [ct_gmt_offset_mins]) VALUES (300, 0, 1, CAST(0x00009CA4002D6B6B AS DateTime), 0, N'FNYCWL00901.TRB_DEV', N'TRB_LDN_DEV', N'TRB London Development Dataserver', 60)
/****** Object:  StoredProcedure [dbo].[SEL_template]    Script Date: 11/22/2012 23:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Md. Marufuzzaman>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--EXEC [SEL_template] 
CREATE PROCEDURE [dbo].[SEL_template]
  @ct_page_index				INT	= 1		 
 ,@ct_page_size					INT	= 10	 
 ,@ct_row_count					INT	= 1		OUTPUT
 ,@ct_page_count				INT	= 1		OUTPUT
-- ,@id_template_key				INT = NULL	OUTPUT
AS
BEGIN
     DECLARE @g_start INT
     DECLARE @g_finish INT
 
     SET @g_start  = ((@ct_page_index * @ct_page_size) - @ct_page_size + 1);
     SET @g_finish = ((@g_start + @ct_page_size) - 1);

 WITH T_TEMP_TABLE AS(
             SELECT ROW_NUMBER() OVER (ORDER BY  ct_record_no	 ASC) AS ct_row_number, *
 	FROM	T_TEMPLATE ) 
		
   SELECT * FROM T_TEMP_TABLE WHERE ct_row_number BETWEEN @g_start AND @g_finish;    
   SELECT @ct_row_count = (SELECT COUNT(*) FROM T_TEMPLATE);
 
     IF ((@ct_row_count % @ct_page_size)=0) 
        BEGIN
			SELECT @ct_page_count = (@ct_row_count / @ct_page_size);
		END
    ELSE    
		BEGIN     
			SELECT @ct_page_count = (@ct_row_count / @ct_page_size) + 1;
		END


END
GO
/****** Object:  StoredProcedure [dbo].[INS_tempate]    Script Date: 11/22/2012 23:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INS_tempate]
 @id_template_key			INT			= NULL
,@tx_template_name			VARCHAR(56)
,@tx_note					VARCHAR(256)= NULL
,@dtt_mod					DATETIME
,@is_active					BIT
AS
BEGIN

DECLARE @g_id_template_key			INT

DECLARE @g_ct_row_count				INT
DECLARE @g_ct_error_count			INT
DECLARE @g_error_message			VARCHAR(128)
DECLARE @g_id_err_code				INT
DECLARE @g_error_msg				VARCHAR(1024)
DECLARE @g_tmp_err_msg				VARCHAR(1024)
	

	INSERT INTO T_TEMPLATE
	   (
			 id_template_key
			,tx_template_name
			,tx_note
			,dtt_mod
			,is_active
	   )
	VALUES
	   (
			 @id_template_key
			,@tx_template_name
			,@tx_note
			,ISNULL(@dtt_mod, GETDATE()) 
			,ISNULL(@is_active, 1)	
		)

	IF ((@@ROWCOUNT = 0) OR (@@ERROR != 0))
	BEGIN
		SELECT @g_error_msg = 'Error encountered while inserting -> T_TEMPLATE ' + '_var_name [' + CONVERT(VARCHAR, @id_template_key) + '] '
		RAISERROR 30008 @g_error_msg
		RETURN 30000									
    END        

END
GO
/****** Object:  StoredProcedure [dbo].[GET_system_key]    Script Date: 11/22/2012 23:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GET_system_key]
	  @tx_key_name		varchar(32)
	, @id_ds_env_key	int
	, @num_keys			int			= 1
	, @is_orm			bit			= 0
	, @id_key_value		int			= NULL	OUTPUT

AS
BEGIN

	-- NEEDS TO BE VERY FAST, hence dispense with standard  template
	-- GLOBAL VARS --
	DECLARE @g_id_ds_env_key	int
	DECLARE @g_tx_ds_name		varchar(32)

	DECLARE @g_row_count		int
	DECLARE @g_ret_status		int

	DECLARE @g_id_err_code		int
	DECLARE @g_error_msg		varchar(1024)
	DECLARE @g_tmp_err_msg		varchar(1024)

	DECLARE @g_is_outer_sp	bit
	DECLARE @g_id_table_bit	int

	DECLARE @g_in_tran		int

	DECLARE @g_tmp_int		int
	DECLARE @g_tmp_tx		varchar(128)
	DECLARE @g_tmp_tx_long	varchar(256)
	DECLARE	@g_tmp_dt		date
	DECLARE @g_tmp_dtt		datetime

	DECLARE @g_dtt_log					datetime
	DECLARE @g_log_pre_msg				varchar(255)
	DECLARE @g_tx_log_msg				varchar(512)

	DECLARE	@g_id_log_current_level		int

	DECLARE @g_is_record_time			int
	DECLARE	@g_is_print_msg				int
	DECLARE @g_is_log_persist_msg  		char(1)
	DECLARE	@g_is_raise_error			int

	SELECT @g_is_raise_error			= 0

	DECLARE @g_dtt_proc_start		datetime
	DECLARE @g_dtt_proc_end			datetime
	DECLARE @g_dtt_tot_elapsed		int

	DECLARE	@g_dtt_query_start		datetime
	DECLARE	@g_dtt_query_end		datetime
	DECLARE @g_dtt_query_elapsed	int

	DECLARE @g_tmp_tx_tot_time		varchar(255)
	DECLARE @g_tmp_tx_query_time	varchar(255)
	
	IF (@id_key_value IS NOT NULL)
	BEGIN
		PRINT 'Key already generated!'
		RETURN 0
	END

	SELECT @num_keys = ISNULL(@num_keys, 1)

	-- IF in a transaction ROLLBACK!
	IF ((@@trancount > 0))
	BEGIN
		SELECT @g_error_msg = 'FATAL : You Should not be in a transaction where T_SYSTEM_KEYS  : Key -> ' + @tx_key_name
		RAISERROR 99999 @g_error_msg
		IF (@g_in_tran = 1)
		BEGIN
			SELECT @g_in_tran = 0
			ROLLBACK TRANSACTION
		END
		RETURN 99999
	END

	IF (@@trancount = 0)
	BEGIN
		SELECT @g_in_tran = 1
		BEGIN TRANSACTION
	END

		--Update first to to lock table
		UPDATE	T_SYSTEM_KEY
		SET		id_key_value	= id_key_value + @num_keys
		WHERE	tx_key_name		= @tx_key_name
		AND		id_ds_env_key	= @id_ds_env_key

		IF ( (@@rowcount = 0) OR (@@error != 0))
		BEGIN
			SELECT @g_error_msg = 'Error encountered while updating -> T_SYSTEM_KEY' + '_var_name [' + convert(varchar, @tx_key_name) + '] '
			RAISERROR 30007 @g_error_msg
			IF (@g_in_tran = 1)
		BEGIN
			SELECT @g_in_tran = 0
			ROLLBACK TRANSACTION
		END
			RETURN 30007
		END

		-- Now work out the key
		SELECT  @id_key_value = id_key_value - @num_keys
		FROM	T_SYSTEM_KEY
		WHERE	tx_key_name		= @tx_key_name
		AND		id_ds_env_key	= @id_ds_env_key

		IF ((@@rowcount = 0) OR (@@error != 0))
		BEGIN
			SELECT @g_error_msg = 'ERROR selecting from T_SYSTEM_KEYS  : Key -> ' + @tx_key_name + 
									'id_ds_env_key -> ' + convert(varchar, @id_ds_env_key)
			RAISERROR 30006 @g_error_msg
			IF (@g_in_tran = 1)
		BEGIN
			SELECT @g_in_tran = 0
			ROLLBACK TRANSACTION
		END
			RETURN 30006
		END

	IF (@g_in_tran = 1)
	BEGIN
		SELECT @g_in_tran = 0
		COMMIT TRANSACTION
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ACT_template]    Script Date: 11/22/2012 23:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ACT_template]
 @tx_action					VARCHAR (16)
,@id_ds_env_key				INT
,@id_template_key			INT			= NULL
,@tx_template_name			VARCHAR(56)
,@tx_note					VARCHAR(256)= NULL
,@dtt_mod					DATETIME
,@is_active					BIT
AS
BEGIN

DECLARE @g_id_template_key			INT
DECLARE @g_id_control_key			INT

DECLARE @g_ct_row_count				INT
DECLARE @g_ct_error_count			INT
DECLARE @g_error_message			VARCHAR(128)
DECLARE @g_row_count				INT
DECLARE @g_ret_status				INT

DECLARE @g_id_err_code				INT
DECLARE @g_error_msg				VARCHAR(1024)
DECLARE @g_tmp_err_msg				VARCHAR(1024)

DECLARE @g_in_tran					INT

------------------
--- ACTION VALIDATION 
 
	IF @tx_action NOT IN ('NEW', 'UPDATE', 'DELETE')
	BEGIN
		SELECT @g_error_msg = 'Invalid action -> ' + ISNULL(@tx_action, '?')
		RAISERROR 30000 @g_error_msg
			IF (@g_in_tran = 1)
			BEGIN
				SELECT @g_in_tran = 0
				ROLLBACK TRANSACTION
			END
	RETURN 30000
	END

	IF(@dtt_mod IS NULL)
	BEGIN
		SET @dtt_mod=GETDATE()
	END
		
	-- IF INSERT THEN GENERATE PRIMARY KEY
	IF ((@tx_action = 'NEW'))
	BEGIN
		-- GET  id_template_key VALUE FROM SYSTEM TABLE
		EXEC @g_ret_status = GET_system_key
									  @id_ds_env_key	= @id_ds_env_key
									, @tx_key_name		= 'id_template_key'
									, @id_key_value		= @id_template_key  OUTPUT
									, @num_keys			= 1

		-- IF ERROR OCCOR ON SELECTING KEY VALUE
		SELECT @g_error_msg = 'Error generating key for id_template_key'
			IF (@g_ret_status != 0)
			BEGIN
				RAISERROR 30003 @g_error_msg
					IF (@g_in_tran = 1)
					BEGIN
						SELECT @g_in_tran = 0
						ROLLBACK TRANSACTION
					END
				RETURN 30003
			END
	END
			
	--INSERT
	IF ( @tx_action = 'NEW')
	BEGIN
		-- START TRANSACTION
		IF (@@TRANCOUNT = 0)
		BEGIN
			SELECT @g_in_tran = 1
			BEGIN TRANSACTION
		END
		
			EXECUTE INS_tempate 
					 @id_template_key
					,@tx_template_name
					,@tx_note
					,@dtt_mod
					,@is_active
	 
		-- IF ERROR THEN ROLLBACK:: INSERT
		IF ( (@@ROWCOUNT = 0) OR (@@ERROR != 0))
		BEGIN
			SELECT @g_error_msg = 'Error encountered while inserting -> T_TEMPLATE ' + '_var_name [' + CONVERT(VARCHAR, @id_template_key) + '] '
			RAISERROR 30008 @g_error_msg
				IF (@g_in_tran = 1)
				BEGIN
					SELECT @g_in_tran = 0
					ROLLBACK TRANSACTION
				END
			RETURN 30008									
		END
		
		-- IF NOT ERROR THEN COMMIT::UPDATE
		IF (@g_in_tran = 1)
		BEGIN
			SELECT @g_in_tran = 0
			COMMIT TRANSACTION
		END

	END

	--UPDATE
	IF ( @tx_action = 'UPDATE')
	BEGIN
		-- TRANSACTION START::UPDATE
		IF (@@TRANCOUNT = 0)
		BEGIN
			SELECT @g_in_tran = 1
			BEGIN TRANSACTION
		END
		-- IF ERROR THEN ROLLBACK:: UPDATE
		IF ( (@@ROWCOUNT = 0) OR (@@ERROR != 0))
		BEGIN
			SELECT @g_error_msg = 'Error encountered while updating -> T_CLIENT ' + '_var_name [' + CONVERT(VARCHAR, @id_template_key) + '] '
			RAISERROR 30007 @g_error_msg
				IF (@g_in_tran = 1)
				BEGIN
					SELECT @g_in_tran = 0
					ROLLBACK TRANSACTION
				END
			RETURN 30007									
		END
		
		-- IF NOT ERROR THEN COMMIT::UPDATE
		IF (@g_in_tran = 1)
		BEGIN
			SELECT @g_in_tran = 0
			COMMIT TRANSACTION
		END

	END
		
	-- DELETE
	IF ((@tx_action = 'DELETE'))
	BEGIN
		SELECT @is_active = 0
	END

	RETURN 

END
GO

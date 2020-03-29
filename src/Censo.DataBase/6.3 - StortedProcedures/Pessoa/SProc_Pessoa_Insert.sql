CREATE PROCEDURE SProc_Pessoa_Insert
(
    @Id             uniqueidentifier NOT NULL,
    @Nome           varchar(100) NOT NULL ,
    @SobreNome      varchar(100) NOT NULL,
    @MaeId          uniqueidentifier NULL,
    @PaiId          uniqueidentifier NULL,
    @GeneroId       tinyint NULL,
    @EtniaId        tinyint NULL,
    @EscolaridadeId tinyint NULL,
	@DataCadastro   datetime NOT NULL
)
As

INSERT INTO [dbo].[tblPessoas]
           ( [Id] 
            ,[Nome] 
            ,[SobreNome] 
            ,[MaeId] 
            ,[PaiId] 
            ,[GeneroId]
            ,[EtniaId] 
            ,[EscolaridadeId]
            ,[DataCadastro] )
     VALUES
           ( @Id
            ,@Nome 
            ,@SobreNome 
            ,@MaeId 
            ,@PaiId 
            ,@GeneroId
            ,@EtniaId 
            ,@EscolaridadeId
            ,@DataCadastro )


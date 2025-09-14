using CreditDeclaration.DBContext;
using CreditDeclaration.Interface;
using CreditDeclaration.Repository;
using CreditDeclaration.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IActiviteService, ActiviteService>().
    AddScoped<IBanqueService, BanqueService>();
builder.Services.AddScoped<IActiviteRepo, ActiviteRepo>().
    AddScoped<IBanqueRepo, BanqueRepo>();
builder.Services.AddScoped<IEntitePubliqueService, EntitePubliqueService>().
    AddScoped<IEntitePubliqueRepo, EntitePubliqueRepo>();
builder.Services.AddScoped<IDureeService, DureeService>().
    AddScoped<IDureeRepo, DureeRepo>();
builder.Services.AddScoped<IClasseRetardService, ClasseRetardService>().
    AddScoped<IClasseRetardRepo, ClasseRetardRepo>();
builder.Services.AddScoped<IEtatCivilService, EtatCivilService>().
    AddScoped<IEtatCivilRepo, EtatCivilRepo>();
builder.Services.AddScoped<IMonnaieService, MonnaieService>().
    AddScoped<IMonnaieRepo, MonnaieRepo>();
builder.Services.AddScoped<IFormeJuridiqueService, FormeJuridiqueService>().
    AddScoped<IFormeJuridiqueRepo, FormeJuridiqueRepo>();

builder.Services.AddScoped<INiveauResponsabiliteService, NiveauResponsabiliteService>().
    AddScoped<INiveauResponsabiliteRepo, NiveauResponsabiliteRepo>();

builder.Services.AddScoped<IWilayaService,WilayaService>().
    AddScoped<IWilayaRepo, WilayaRepo>();

builder.Services.AddScoped<ICommuneService, CommuneService>().
    AddScoped<ICommuneRepo, CommuneRepo>();

builder.Services.AddScoped<IProfessionService, ProfessionService>().
    AddScoped<IProfessionRepo, ProfessionRepo>();

builder.Services.AddScoped<ISituationCreditService, SituationCreditService>().
    AddScoped<ISituationCreditRepo, SituationCreditRepo>();

builder.Services.AddScoped<ISourceInformationService, SourceInformationService>().
    AddScoped<ISourceInformationRepo, SourceInformationRepo>();

builder.Services.AddScoped<IPaysService, PaysService>().
    AddScoped<IPaysRepo, PaysRepo>();

builder.Services.AddScoped<ITypePersonneService, TypePersonneService>().
    AddScoped<ITypePersonneRepo, TypePersonneRepo>();

builder.Services.AddScoped<ITypeCreditService, TypeCreditService>().
    AddScoped<ITypeCreditRepo, TypeCreditRepo>();

builder.Services.AddScoped<ITypeGarantieService, TypeGarantieService>().
    AddScoped<ITypeGarantieRepo, TypeGarantieRepo>();

builder.Services.AddScoped<ITypeDocumentService, TypeDocumentService>().
    AddScoped<ITypeDocumentRepo, TypeDocumentRepo>();

builder.Services.AddScoped<IPersonnePhysiqueService, PersonnePhysiqueService>().
    AddScoped<IPersonnePhysiqueRepo, PersonnePhysiqueRepo>();

//builder.Services.AddScoped<IPersonnePhysiqueService, PersonnePhysiqueService>().
//  AddScoped<IPersonnePhysiqueRepo, NiveauResponsabiliteRepo>();


builder.Services.AddScoped<IFonctionDirigeantService, FonctionDirigeantService>().
    AddScoped<IFonctionDirigeantRepo, FonctionDirigeantRepo>();
//builder.Services.AddScoped<IPersonneMoralRepo, PersonneMoralRepo>().
//  AddScoped<IPersonneMoralRepo, PersonneMoralRepo>();
/* .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
 {
     option.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateAudience = true,
         ValidateIssuer = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = builder.Configuration["Token:Issuer"],
         ValidAudience = builder.Configuration["Token:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
         ClockSkew = TimeSpan.Zero
     };
 });*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//, b => b.MigrationsAssembly("ApiGateway")

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3001", "http://10.100.6.30:8090", "https://simulateur.bnh.lan", "http://simulateur.bnh.lan", "http://10.16.6.225:7000") // Add frontend URLs
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader());

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowSpecificOrigin");
app.Run();

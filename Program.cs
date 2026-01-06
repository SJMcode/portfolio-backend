using PortfolioApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Force console logging to appear in Railway
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173", "https://sjmcode.github.io", "https://smarteksolutions.se", "http://smarteksolutions.se")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

Console.WriteLine("========================================");
Console.WriteLine("APP BUILT SUCCESSFULLY");
Console.WriteLine("========================================");

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");

app.MapGet("/", () =>
{
    Console.WriteLine("ROOT ENDPOINT HIT!");
    return "API is running";
});

app.MapGet("/api/profile", () =>
{
    var profile = new Profile
    {
        Name = "Safir Jameel",
        Title = "Software Engineer",
        Location = "Solna, Stockholm, Sweden",
        Email = "safir.jameel@gmail.com",
        Phone = "+46 707 217 ***",
        LinkedIn = "safir-jameel",
        GitHub = "SJMcode",
        Summary = @"Software Developer with 2 years of full‑stack experience and 3 years in IT support. Skilled in building scalable, secure, and maintainable applications that align with business requirements. Strong foundation in backend and frontend development, combined with hands‑on expertise in troubleshooting, system support, and delivering reliable technical solutions. Passionate about creating high‑quality software that enhances user experience and supports long‑term growth."
    };
    return Results.Ok(profile);
});

app.MapGet("/api/experience", () =>
{
    var experiences = new List<Experience>
    {
        new Experience
        {
            Role = "Software Engineer",
            Company = "Brotoype",
            Location = "Cochin,India, (remote),
            Period = "Jan 2026 – Present",
            Responsibilities = new()
            {
                "Developed and maintained full-stack web solutions using .NET and React, improving load times/scalability.",
                "Architected responsive UI components using TypeScript and Tailwind CSS, ensuring a consistent user experience across platforms.",
                "Collaborated in a remote-first team to deliver high-quality code following [Agile/Scrum] methodologies."
            }
        },
        new Experience
        {
            Role = "Software Developer",
            Company = "Acugence Software Development Company",
            Location = "Doha, Qatar",
            Period = "Oct 2021 – Jun 2022",
            Responsibilities = new()
            {
                "Built a React application improving front-end performance by 30%.",
                "Developed RESTful APIs using .NET.",
                "Deployed applications on AWS EC2 using CI/CD pipelines.",
                "Maintained WordPress websites with SEO optimization.",
                "Implemented backend functionality using .NET and Azure."
            }
        },
        new Experience
        {
            Role = "IT Analyst",
            Company = "Aspire Academy",
            Location = "Doha, Qatar",
            Period = "Jan 2015 – Jun 2019",
            Responsibilities = new()
            {
                "Provided IT support and systems maintenance.",
                "Oversaw hardware/software installations.",
                "Implemented data backup and recovery protocols.",
                "Supported digital learning platforms."
            }
        }
    };
    return Results.Ok(experiences);
});

app.MapGet("/api/skills", () =>
{
    var skills = new List<Skill>
    {
        new Skill { Name = "C#.NET" },
        new Skill { Name = "SQL" },
        new Skill { Name = "Docker" },
        new Skill { Name = "Kubernetes" },
        new Skill { Name = "Python" },
        new Skill { Name = "AWS EC2" },
        new Skill { Name = "Networking (TCP/IP, VLAN, VPN)" },
        new Skill {Name = "React Typescript Tailwind"},
        new Skill {Name = "Node.js  "},
        new Skill {Name = "Languages: English - Professional, Swedish (B2), German (A2)"},
    };
    return Results.Ok(skills);
});

app.MapGet("/api/projects", () =>
{
    var projects = new List<Project>
    {
        new Project
        {
            Title = "Portfolio Website",
            Description = "A full-stack portfolio built with React and .NET.",
            TechStack = "React, .NET, Azure",
            GitHubUrl = "https://github.com/SJMcode"
        }
    };
    return Results.Ok(projects);
});

Console.WriteLine("========================================");
//Console.WriteLine($"STARTING APP ON PORT {port}");
Console.WriteLine("========================================");

app.Run();
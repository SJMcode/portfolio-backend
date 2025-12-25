using PortfolioApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader());
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowFrontend");

// ----------------------
// Profile Endpoint
// ----------------------
app.MapGet("/api/profile", () =>
{
    var profile = new Profile
    {
        Name = "Safir Jameel M",
        Title = "Software Engineer",
        Location = "Solna, Stockholm, Sweden",
        Email = "safir.jameel@gmail.com",
        Phone = "+46 707 217 399",
        LinkedIn = "safir-jameel",
        GitHub = "SJMcode",
        Summary = "Software Developer with 2 years of full-stack experience and 3 years in IT support..."
    };

    return Results.Ok(profile);
});

// ----------------------
// Experience Endpoint
// ----------------------
app.MapGet("/api/experience", () =>
{
    var experiences = new List<Experience>
    {
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

// ----------------------
// Skills Endpoint
// ----------------------
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
        new Skill { Name = "Networking (TCP/IP, VLAN, VPN)" }
    };

    return Results.Ok(skills);
});

// ----------------------
// Projects Endpoint
// ----------------------
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

app.Run();

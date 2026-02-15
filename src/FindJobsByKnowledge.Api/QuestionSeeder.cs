using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FindJobsByKnowledge.Api;

/// <summary>
/// Seeds the database with at least 5 questions per level (1-5) for each tag.
/// Only inserts if no questions exist yet.
/// </summary>
public static class QuestionSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.Questions.AnyAsync()) return;

        var questions = new List<Question>();

        questions.AddRange(GetCSharpQuestions());
        questions.AddRange(GetReactQuestions());
        questions.AddRange(GetDockerQuestions());

        foreach (var q in questions)
        {
            q.Id = Guid.NewGuid();
            q.CreatedAt = DateTime.UtcNow;
        }

        db.Questions.AddRange(questions);
        await db.SaveChangesAsync();
    }

    private static List<Question> GetCSharpQuestions() =>
    [
        // Level 1 - Beginner
        new() { Tag = "C#", Level = 1, Text = "What keyword is used to declare a variable that cannot be reassigned?", Options = ["const", "var", "static", "readonly"], CorrectOptionIndex = 0 },
        new() { Tag = "C#", Level = 1, Text = "Which data type is used to store a single character in C#?", Options = ["string", "char", "int", "bool"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 1, Text = "What does 'Console.WriteLine' do?", Options = ["Reads input from the console", "Writes output to the console", "Clears the console", "Pauses the console"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 1, Text = "Which symbol is used for single-line comments in C#?", Options = ["/* */", "#", "//", "--"], CorrectOptionIndex = 2 },
        new() { Tag = "C#", Level = 1, Text = "What is the default value of a bool in C#?", Options = ["true", "false", "null", "0"], CorrectOptionIndex = 1 },

        // Level 2 - Intermediate
        new() { Tag = "C#", Level = 2, Text = "What is the purpose of the 'using' statement in C#?", Options = ["Import namespaces", "Ensure disposal of resources", "Create a new scope", "Both A and B"], CorrectOptionIndex = 3 },
        new() { Tag = "C#", Level = 2, Text = "Which collection type enforces unique elements?", Options = ["List<T>", "Dictionary<K,V>", "HashSet<T>", "Queue<T>"], CorrectOptionIndex = 2 },
        new() { Tag = "C#", Level = 2, Text = "What is the difference between 'ref' and 'out' parameters?", Options = ["ref must be initialized before passing", "out must be initialized before passing", "They are identical", "ref is for value types only"], CorrectOptionIndex = 0 },
        new() { Tag = "C#", Level = 2, Text = "What does the 'virtual' keyword indicate on a method?", Options = ["The method is abstract", "The method can be overridden in derived classes", "The method is static", "The method is sealed"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 2, Text = "What is an interface in C#?", Options = ["A class that cannot be instantiated", "A contract that defines members a class must implement", "A base class with default implementations", "A collection type"], CorrectOptionIndex = 1 },

        // Level 3 - Self-sufficient
        new() { Tag = "C#", Level = 3, Text = "What is the difference between IEnumerable<T> and IQueryable<T>?", Options = ["IQueryable executes in-memory, IEnumerable on the server", "IEnumerable is for in-memory collections, IQueryable for remote data sources with deferred execution", "They are identical", "IQueryable doesn't support LINQ"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 3, Text = "What is a delegate in C#?", Options = ["A reference type that holds a method reference", "A value type for events", "An abstract class", "A static method container"], CorrectOptionIndex = 0 },
        new() { Tag = "C#", Level = 3, Text = "What does the 'async/await' pattern accomplish?", Options = ["Runs code on multiple threads simultaneously", "Enables asynchronous programming without blocking the calling thread", "Makes code run faster", "Replaces try/catch blocks"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 3, Text = "What is dependency injection?", Options = ["A design pattern where dependencies are provided to a class rather than created internally", "A way to inject code at runtime", "A testing framework", "A type of inheritance"], CorrectOptionIndex = 0 },
        new() { Tag = "C#", Level = 3, Text = "What is the purpose of the 'yield' keyword?", Options = ["To stop execution permanently", "To create an iterator that returns elements one at a time", "To throw an exception", "To define a constant"], CorrectOptionIndex = 1 },

        // Level 4 - Expert
        new() { Tag = "C#", Level = 4, Text = "What is covariance and contravariance in C# generics?", Options = ["Covariance allows a more derived type, contravariance allows a less derived type", "They define type constraints", "They control access modifiers", "They handle null references"], CorrectOptionIndex = 0 },
        new() { Tag = "C#", Level = 4, Text = "What is the Span<T> type used for?", Options = ["Storing immutable sequences", "Providing type-safe, memory-safe access to contiguous memory regions", "Managing database connections", "Handling async operations"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 4, Text = "How does the garbage collector handle generations?", Options = ["Gen0 for long-lived, Gen2 for short-lived objects", "Gen0 for short-lived, Gen1 for medium, Gen2 for long-lived objects", "All objects are in one generation", "Generations are only for value types"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 4, Text = "What is the difference between Task.Run and Task.Factory.StartNew?", Options = ["They are identical", "Task.Run is a simplified wrapper with sensible defaults; StartNew offers more configuration options", "Task.Run runs synchronously", "StartNew is deprecated"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 4, Text = "What is an expression tree in C#?", Options = ["A binary search tree implementation", "A data structure representing code as a tree of expressions that can be inspected and modified", "A UI rendering mechanism", "A logging framework"], CorrectOptionIndex = 1 },

        // Level 5 - Proficient
        new() { Tag = "C#", Level = 5, Text = "How does the C# compiler handle closures over loop variables?", Options = ["Each iteration captures its own variable copy", "All iterations share the same captured variable (pre-C#5); each captures its own copy (C#5+ for foreach)", "Loop variables cannot be captured", "Closures are not supported in loops"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 5, Text = "What is the ConfigureAwait(false) method used for?", Options = ["To disable async/await", "To avoid capturing the synchronization context, improving performance in library code", "To force execution on the UI thread", "To cancel a task"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 5, Text = "What are Source Generators in C#?", Options = ["Runtime code generation tools", "Compile-time components that generate additional C# source code during compilation", "A debugging tool", "A package manager feature"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 5, Text = "What is the difference between ValueTask<T> and Task<T>?", Options = ["They are identical", "ValueTask<T> is a struct that avoids heap allocation when the result is available synchronously", "Task<T> is faster", "ValueTask<T> is only for void methods"], CorrectOptionIndex = 1 },
        new() { Tag = "C#", Level = 5, Text = "How does the .NET JIT compiler handle tiered compilation?", Options = ["It compiles all code at the highest optimization level", "It first compiles methods quickly (Tier 0), then recompiles hot methods with full optimizations (Tier 1)", "It only interprets code", "Tiered compilation is only for AOT scenarios"], CorrectOptionIndex = 1 },
    ];

    private static List<Question> GetReactQuestions() =>
    [
        // Level 1 - Beginner
        new() { Tag = "React", Level = 1, Text = "What is JSX?", Options = ["A database query language", "A syntax extension that allows writing HTML-like code in JavaScript", "A CSS framework", "A testing library"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 1, Text = "What function is used to render a React component to the DOM?", Options = ["React.render()", "ReactDOM.createRoot().render()", "document.render()", "React.mount()"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 1, Text = "What is a React component?", Options = ["A CSS class", "A reusable piece of UI that can accept inputs (props) and return JSX", "A database table", "A server endpoint"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 1, Text = "What are props in React?", Options = ["Internal state of a component", "Read-only inputs passed from a parent to a child component", "CSS properties", "Event handlers"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 1, Text = "How do you create a functional component in React?", Options = ["class MyComponent extends React.Component", "function MyComponent() { return <div/> }", "React.createComponent()", "new Component()"], CorrectOptionIndex = 1 },

        // Level 2 - Intermediate
        new() { Tag = "React", Level = 2, Text = "What hook is used to manage state in a functional component?", Options = ["useEffect", "useState", "useRef", "useContext"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 2, Text = "What is the purpose of the useEffect hook?", Options = ["To manage component state", "To perform side effects like data fetching or subscriptions", "To create refs", "To memoize values"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 2, Text = "Why is the 'key' prop important in lists?", Options = ["It styles list items", "It helps React identify which items changed, were added, or removed", "It defines sort order", "It is optional and has no effect"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 2, Text = "What is conditional rendering in React?", Options = ["Rendering only on certain devices", "Showing different UI based on conditions using ternary operators, && or if statements", "A server-side rendering technique", "A CSS media query alternative"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 2, Text = "What is the difference between controlled and uncontrolled components?", Options = ["Controlled components manage their own DOM state; uncontrolled use React state", "Controlled components have their value managed by React state; uncontrolled manage their own DOM state", "There is no difference", "Uncontrolled components cannot have events"], CorrectOptionIndex = 1 },

        // Level 3 - Self-sufficient
        new() { Tag = "React", Level = 3, Text = "What is the useCallback hook used for?", Options = ["To fetch data from APIs", "To memoize a callback function, preventing unnecessary re-creations on re-renders", "To manage form state", "To create side effects"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 3, Text = "What is React Context and when should you use it?", Options = ["A routing library", "A way to share values across the component tree without prop drilling", "A state management library like Redux", "A testing utility"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 3, Text = "What is the purpose of React.memo()?", Options = ["To create memoized values", "To prevent unnecessary re-renders of a component when its props haven't changed", "To manage memory allocation", "To create memo notes in code"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 3, Text = "How does the useReducer hook differ from useState?", Options = ["useReducer is for server state", "useReducer manages complex state logic with a reducer function, similar to Redux patterns", "useReducer is deprecated", "There is no difference"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 3, Text = "What are custom hooks and why are they useful?", Options = ["Hooks that only work in class components", "Reusable functions prefixed with 'use' that encapsulate stateful logic for sharing across components", "A way to modify React internals", "Third-party npm packages"], CorrectOptionIndex = 1 },

        // Level 4 - Expert
        new() { Tag = "React", Level = 4, Text = "How does React's reconciliation algorithm (diffing) work?", Options = ["It re-renders the entire DOM every time", "It compares virtual DOM trees using heuristics: same-type elements update, different-type elements unmount/remount", "It uses a database diff engine", "It only works with class components"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 4, Text = "What is a render prop pattern?", Options = ["A CSS rendering technique", "A technique where a component receives a function as prop that returns JSX, enabling flexible rendering logic", "A React Router feature", "A form validation pattern"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 4, Text = "What is Suspense and how does it work with lazy loading?", Options = ["A debugging tool", "A component that displays fallback UI while waiting for lazy-loaded components or async data to resolve", "A CSS animation library", "A server-side rendering framework"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 4, Text = "How do Error Boundaries work in React?", Options = ["They catch JavaScript errors in any code", "They are class components using componentDidCatch/getDerivedStateFromError to catch errors in child component trees", "They are try/catch blocks for JSX", "They only work with hooks"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 4, Text = "What is the purpose of useImperativeHandle?", Options = ["To handle form submissions", "To customize the instance value exposed to parent components when using forwardRef", "To create imperative animations", "To manage global state"], CorrectOptionIndex = 1 },

        // Level 5 - Proficient
        new() { Tag = "React", Level = 5, Text = "How does React's Fiber architecture improve rendering?", Options = ["It uses Web Workers", "It breaks rendering work into units that can be paused, aborted, or prioritized, enabling concurrent rendering", "It compiles JSX to native code", "It eliminates the virtual DOM"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 5, Text = "What are React Server Components and how do they differ from Client Components?", Options = ["Server Components run on the client with server data", "Server Components render on the server with zero client JS bundle, while Client Components hydrate and handle interactivity", "They are the same as SSR", "Server Components replace all client-side rendering"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 5, Text = "How does the useSyncExternalStore hook work?", Options = ["It syncs React state with localStorage", "It subscribes to external stores with tearing-prevention guarantees for concurrent rendering", "It syncs state between components", "It stores data in IndexedDB"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 5, Text = "What is the purpose of the useTransition hook?", Options = ["To animate component mounting", "To mark state updates as non-urgent transitions, keeping the UI responsive during expensive re-renders", "To transition between pages", "To handle CSS transitions"], CorrectOptionIndex = 1 },
        new() { Tag = "React", Level = 5, Text = "How does automatic batching work in React 18+?", Options = ["It batches API calls", "React automatically batches all state updates (including in promises, timeouts, and event handlers) into a single re-render", "It only batches useState calls", "Batching must be manually enabled"], CorrectOptionIndex = 1 },
    ];

    private static List<Question> GetDockerQuestions() =>
    [
        // Level 1 - Beginner
        new() { Tag = "Docker", Level = 1, Text = "What is Docker?", Options = ["A programming language", "A platform for building, shipping, and running applications in containers", "A database system", "A web framework"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 1, Text = "What is the command to run a Docker container?", Options = ["docker start", "docker run", "docker exec", "docker create"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 1, Text = "What is a Docker image?", Options = ["A running instance of a container", "A read-only template used to create containers", "A virtual machine", "A configuration file"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 1, Text = "What file defines how to build a Docker image?", Options = ["docker-compose.yml", "Dockerfile", "package.json", "config.yml"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 1, Text = "What command lists all running Docker containers?", Options = ["docker images", "docker ps", "docker list", "docker containers"], CorrectOptionIndex = 1 },

        // Level 2 - Intermediate
        new() { Tag = "Docker", Level = 2, Text = "What is the purpose of docker-compose?", Options = ["To build single containers", "To define and run multi-container Docker applications using a YAML file", "To push images to a registry", "To monitor container health"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 2, Text = "What is a Docker volume used for?", Options = ["To increase container CPU", "To persist data beyond the container's lifecycle", "To limit network access", "To compress images"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 2, Text = "What does the EXPOSE instruction do in a Dockerfile?", Options = ["Opens ports on the host machine", "Documents which ports the container listens on (does not actually publish them)", "Blocks outgoing traffic", "Exposes environment variables"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 2, Text = "What is the difference between CMD and ENTRYPOINT?", Options = ["They are identical", "CMD provides defaults that can be overridden; ENTRYPOINT defines the main executable that always runs", "ENTRYPOINT is deprecated", "CMD runs before ENTRYPOINT"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 2, Text = "What is a Docker network?", Options = ["An external WiFi connection", "An isolated network that allows containers to communicate with each other", "A monitoring dashboard", "A CI/CD pipeline"], CorrectOptionIndex = 1 },

        // Level 3 - Self-sufficient
        new() { Tag = "Docker", Level = 3, Text = "What is a multi-stage build and why is it useful?", Options = ["Building multiple containers at once", "Using multiple FROM statements to create smaller, optimized production images by separating build-time from runtime dependencies", "Running tests in Docker", "A CI/CD integration feature"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 3, Text = "How do you pass environment variables to a Docker container?", Options = ["Only through Dockerfile", "Using -e flag, --env-file, or environment section in docker-compose.yml", "Through the container's filesystem", "Environment variables are not supported"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 3, Text = "What is the difference between ADD and COPY in a Dockerfile?", Options = ["They are identical", "ADD can extract tar archives and fetch URLs; COPY only copies local files (COPY is preferred for simple copies)", "COPY is deprecated", "ADD is faster"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 3, Text = "How does Docker layer caching work?", Options = ["Docker doesn't cache anything", "Each instruction creates a layer; unchanged layers are cached and reused, speeding up subsequent builds", "Caching is only for volumes", "Layers are always rebuilt"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 3, Text = "What is .dockerignore used for?", Options = ["Ignoring Docker commands", "Excluding files and directories from the build context to reduce image size and build time", "Ignoring container logs", "Disabling Docker features"], CorrectOptionIndex = 1 },

        // Level 4 - Expert
        new() { Tag = "Docker", Level = 4, Text = "What are Docker namespaces and cgroups?", Options = ["Docker plugins", "Linux kernel features: namespaces provide isolation (PID, network, mount); cgroups limit resource usage (CPU, memory)", "Container orchestration tools", "Image registry features"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 4, Text = "How would you troubleshoot a container that keeps crashing?", Options = ["Restart Docker Engine", "Use docker logs, docker inspect, check exit codes, run interactively with docker run -it, and review resource constraints", "Delete and recreate the image", "Increase host RAM"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 4, Text = "What is Docker BuildKit and what advantages does it offer?", Options = ["A UI for Docker Desktop", "A modern build engine offering parallel build stages, better caching, secret mounting, and smaller build contexts", "A container runtime", "A logging tool"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 4, Text = "How do you implement health checks in Docker?", Options = ["Docker monitors health automatically", "Using the HEALTHCHECK instruction in Dockerfile or healthcheck config in compose, which runs a command periodically to check container health", "Health checks are only in Kubernetes", "By monitoring CPU usage"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 4, Text = "What is container orchestration and how does Docker Swarm compare to Kubernetes?", Options = ["They are the same", "Both manage container deployment at scale; Swarm is simpler and built-in, Kubernetes is more feature-rich for complex workloads", "Docker Swarm replaced Kubernetes", "Orchestration is only for VMs"], CorrectOptionIndex = 1 },

        // Level 5 - Proficient
        new() { Tag = "Docker", Level = 5, Text = "How would you implement a zero-downtime deployment with Docker?", Options = ["Stop old container, start new one", "Use rolling updates with health checks, blue-green or canary deployments, load balancer draining, and proper signal handling (SIGTERM)", "Zero-downtime is impossible with Docker", "Just use faster hardware"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 5, Text = "How do you scan Docker images for vulnerabilities?", Options = ["Docker images are always secure", "Use tools like docker scout, Trivy, or Snyk to scan layers for known CVEs and enforce policies in CI/CD pipelines", "By reading the Dockerfile", "Vulnerabilities are only in base OS"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 5, Text = "What are rootless containers and why are they important?", Options = ["Containers without a filesystem root", "Containers that run without root privileges on the host, reducing the attack surface if a container escape occurs", "Containers without an entrypoint", "They are experimental and not production-ready"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 5, Text = "How does Docker content trust (DCT) work?", Options = ["It encrypts container traffic", "It uses digital signatures via Notary/TUF to verify image integrity and publisher identity, preventing tampered images from running", "It validates Dockerfiles", "It manages user authentication"], CorrectOptionIndex = 1 },
        new() { Tag = "Docker", Level = 5, Text = "What strategies would you use to minimize Docker image size in production?", Options = ["Use the largest base image available", "Use multi-stage builds, distroless/Alpine bases, combine RUN layers, remove package caches, use .dockerignore, and avoid installing unnecessary packages", "Image size doesn't matter", "Only use official images"], CorrectOptionIndex = 1 },
    ];
}

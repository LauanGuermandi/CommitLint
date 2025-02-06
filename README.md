# 🚀 CommitLint CLI - Enforce Conventional Commit Messages  

**CommitLint CLI** is a simple yet powerful .NET command-line tool that validates commit messages against the [Conventional Commits](https://www.conventionalcommits.org/) specification. It ensures commit messages follow a structured format, improving project maintainability, automation, and changelog generation.  

## ✨ Features  
- ✅ **Automatic Validation** – Checks commit messages for compliance with Conventional Commits.  
- 🔧 **Customizable & Extensible** – Easily integrate into your CI/CD pipeline.  
- 🛠 **Git Hooks Support** – Works seamlessly with [Husky.NET](https://github.com/tonerdo/husky.net) for pre-commit validation.  
- ⚡ **Fast & Lightweight** – Built with .NET and optimized for speed.  

## 🚀 Usage  
Run the CLI tool with:  
```sh
CommitLint <commit-message-file>
```

Example commit messages:
✅ feat(auth): add OAuth support – Valid
✅ feat: add OAuth support – Valid
❌ fixed the bug – Invalid

## 🔗 Integration with Git Hooks (Husky.NET)

To automatically enforce commit message rules before every commit, use Husky.NET:

```sh
dotnet new tool-manifest
dotnet tool install CommitLint
dotnet tool install Husky
dotnet husky add commit-msg -c "CommitLint .git/COMMIT_EDITMSG"
```

📦 Installation

Install Globally
```sh
dotnet tool install --global CommitLint
```

Install Locally
```sh
dotnet tool install --local CommitLint
```

📜 License
Licensed under the **BSD 2-Clause**.

---
Would you like any adjustments? 😊

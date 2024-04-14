# Config Enviroment Manager
Reads config from environment variables with support to look up values from AWS SSM Parameter Store

## Usage
### Read from environment
```C#
var aws_region = Config.Instance.GetEnv("AWS_DEFAULT_REGION");
```

### From AWS
If reading value from AWS Parameter Store, the variable should be prefixed with `AWS_SSM_`

For example, we want to load the secret is stored in `/application/secret`

The environment variable defines path to SSM Parameter Store
```bash
AWS_SSM_MY_SECRET='/application/mysecret'
```

```C#
var secret = Config.Instance.GetEnv("AWS_SSM_MY_SECRET");
```

The application retrieves the secret directly from SSM Parameter Store

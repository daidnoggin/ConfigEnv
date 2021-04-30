# Config Enviroment Manager
Reads config from environment variables with support for AWS SSM Parameter Store

## Usage
### Read from environment
```C#
var aws_region = Config.Instance.GetEnv("AWS_DEFAULT_REGION");
```

### From AWS
Within AWS SSM Parameter store, the secret is stored in `/application/secret`

Environment variable defines path to SSM Parameter Store
```bash
AWS_SSM_MY_SECRET='/application/mysecret'
```

```C#
var secret = Config.Instance.GetEnv("AWS_SSM_MY_SECRET");
```

The application retrives the secret directly


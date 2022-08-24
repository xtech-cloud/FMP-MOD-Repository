# 部署指南

## Repository (仓库)

### 存储引擎

#### MinIO

- 创建Bucket
- 在Bucket的AccessRules中添加一条readonly的访问规则，prefix填写"/"
- 检查Bucket的Access policy是否已经更新为custom，并检查policy
- 配置appsettings.json中的以下部分
  ```json
  "MinIO": {
      "Address": "localhost:9000",
      "Endpoint": "localhost:9000",
      "Bucket": "fmp.repository",
      "AccessKey": "******",
      "SecretKey": "******"
  }
  ```
  Address为MinIO在外网可访问的地址，此地址用于生成上传地址。
  Endpoint为MinIO在内网可访问的地址，此地址用于在服务内部进行通信。
  AccessKey和SecretKey为MinIO生成的Access Account。

# 使用手册

## Repository (仓库)

- FMP项目的fmp.yaml中的publish任务中，修改repository字段为grpc://localhost:18000,指向本服务运行的地址
- 在FMP项目构建后，在fmp.yaml的路径运行fmp-cli，完成模块的发布。
- 访问网页，查看对应内容。

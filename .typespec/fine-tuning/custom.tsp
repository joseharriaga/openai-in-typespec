using TypeSpec.OpenAPI;

namespace OpenAI;

union CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersBatchSizeOption {
  CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum,
  int32,
}

union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption {
  CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum,
  float32,
}

union CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersNEpochsOption {
  CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum,
  int32,
}

union CreateFineTuningJobRequestHyperparametersBetaChoiceEnum {
  auto: "auto",
}

union CreateFineTuningJobRequestHyperparametersBetaOption {
  CreateFineTuningJobRequestHyperparametersBetaChoiceEnum,
  int32,
}

union FineTuningJobHyperparametersBatchSizeChoiceEnum {
  auto: "auto",
}

union FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum {
  auto: "auto",
}

union FineTuningJobHyperparametersNEpochsChoiceEnum {
  auto: "auto",
}

@discriminator("type")
model CreateFineTuningJobRequestIntegration {
  type: string;
}

model CreateFineTuningJobRequestWandbIntegration
  extends CreateFineTuningJobRequestIntegration {
  type: "wandb";
  wandb: {
    project: string;
    name?: string | null;
    entity?: string | null;
    tags?: string[];
  };
}

@discriminator("type")
model FineTuningIntegration {
  type: string;
}

model FineTuningJobsPageToken {
  limit?: int32;
  after?: string;
}

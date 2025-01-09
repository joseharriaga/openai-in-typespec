using TypeSpec.OpenAPI;

namespace OpenAI;

union CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum {
  auto: "auto",
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

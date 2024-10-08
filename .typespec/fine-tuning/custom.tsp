using TypeSpec.OpenAPI;

namespace OpenAI;

model CreateFineTuningJobRequestHyperparameters {
  /**
   * The number of epochs to train the model for. An epoch refers to one full cycle
   * through the training dataset.
   */
  @minValue(1)
  @maxValue(50)
  n_epochs?: CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum | int32 = CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum.auto;

  /**
   * Number of examples in each batch. A larger batch size means that model parameters
   * are updated less frequently, but with lower variance.
   */
  @minValue(1)
  @maxValue(256)
  batch_size?: CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum | int32 = CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum.auto;

  /**
   * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
   * overfitting.
   */
  @minValue(0)
  learning_rate_multiplier?: CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum | float32 = CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.auto;
}

union CreateFineTuningJobRequestHyperparametersBatchSizeChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum {
  auto: "auto",
}
union CreateFineTuningJobRequestHyperparametersNEpochsChoiceEnum {
  auto: "auto",
}

model FineTuningJobHyperparameters {
  /**
   * The number of epochs to train the model for. An epoch refers to one full cycle
   * through the training dataset.
   */
  n_epochs: FineTuningJobHyperparametersNEpochsChoiceEnum | int32 = FineTuningJobHyperparametersNEpochsChoiceEnum.auto;

  /**
   * Number of examples in each batch. A larger batch size means that model parameters
   * are updated less frequently, but with lower variance.
   */
  batch_size: FineTuningJobHyperparametersBatchSizeChoiceEnum | int32 = FineTuningJobHyperparametersBatchSizeChoiceEnum.auto;

  /**
   * Scaling factor for the learning rate. A smaller learning rate may be useful to avoid
   * overfitting.
   */
  learning_rate_multiplier: FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum | float32 = FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum.auto;
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

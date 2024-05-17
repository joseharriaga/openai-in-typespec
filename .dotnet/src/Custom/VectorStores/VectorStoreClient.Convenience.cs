using System;
using System.ClientModel;
using System.Threading.Tasks;
using OpenAI.Files;

namespace OpenAI.VectorStores;

public partial class VectorStoreClient
{
    /// <summary>
    /// Modifies an existing vector store.
    /// </summary>
    /// <param name="vectorStore"> The vector store to modify. </param>
    /// <param name="options"> The new options to apply to the vector store. </param>
    /// <returns> The modified vector store instance. </returns>
    public virtual Task<ClientResult<VectorStore>> ModifyVectorStoreAsync(VectorStore vectorStore, VectorStoreModificationOptions options)
        => ModifyVectorStoreAsync(vectorStore?.Id, options);

    /// <summary>
    /// Modifies an existing vector store.
    /// </summary>
    /// <param name="vectorStore"> The vector store to modify. </param>
    /// <param name="options"> The new options to apply to the vector store. </param>
    /// <returns> The modified vector store instance. </returns>
    public virtual ClientResult<VectorStore> ModifyVectorStore(VectorStore vectorStore, VectorStoreModificationOptions options)
        => ModifyVectorStore(vectorStore?.Id, options);

    /// <summary>
    /// Gets an up-to-date instance of an existing vector store.
    /// </summary>
    /// <param name="vectorStore"> The existing vector store instance to get an updated instance of. </param>
    /// <returns> The refreshed vector store instance. </returns>
    public virtual Task<ClientResult<VectorStore>> GetVectorStoreAsync(VectorStore vectorStore)
        => GetVectorStoreAsync(vectorStore?.Id);

    /// <summary>
    /// Gets an up-to-date instance of an existing vector store.
    /// </summary>
    /// <param name="vectorStore"> The existing vector store instance to get an updated instance of. </param>
    /// <returns> The refreshed vector store instance. </returns>
    public virtual ClientResult<VectorStore> GetVectorStore(VectorStore vectorStore)
        => GetVectorStore(vectorStore?.Id);

    /// <summary>
    /// Deletes a vector store.
    /// </summary>
    /// <param name="vectorStore"> The vector store to delete. </param>
    /// <returns> A value indicating whether the deletion operation was successful. </returns>
    public virtual Task<ClientResult<bool>> DeleteVectorStoreAsync(VectorStore vectorStore)
        => DeleteVectorStoreAsync(vectorStore?.Id);

    /// <summary>
    /// Deletes a vector store.
    /// </summary>
    /// <param name="vectorStore"> The vector store to delete. </param>
    /// <returns> A value indicating whether the deletion operation was successful. </returns>
    public virtual ClientResult<bool> DeleteVectorStore(VectorStore vectorStore)
        => DeleteVectorStore(vectorStore?.Id);

    public virtual Task<ClientResult<VectorStoreFileAssociation>> AddFileToVectorStoreAsync(VectorStore vectorStore, OpenAIFileInfo file)
        => AddFileToVectorStoreAsync(vectorStore?.Id, file?.Id);

    public virtual ClientResult<VectorStoreFileAssociation> AddFileToVectorStore(VectorStore vectorStore, OpenAIFileInfo file)
        => AddFileToVectorStore(vectorStore?.Id, file?.Id);

    //public virtual AsyncPageableCollection<VectorStoreFileAssociation> GetVectorStoreFileAssociationsAsync(VectorStore vectorStore, ListOrder? resultOrder = null)
    //    => GetVectorStoreFileAssociationsAsync(vectorStore?.Id, resultOrder);

    //public virtual PageableCollection<VectorStoreFileAssociation> GetVectorStoreFileAssociations(VectorStore vectorStore, ListOrder? resultOrder = null)
    //    => GetVectorStoreFileAssociations(vectorStore?.Id, resultOrder);
}

using MediaPager.App.PluginContracts;

namespace MediaPager.Plugins.Stream.Local;

/// <summary>
/// Marks catalog-backed local playback as an official stream capability. The host serves
/// local files through its catalog capability URLs; this provider intentionally contributes
/// no browsable sources and exposes no library operations to other plugins.
/// </summary>
public sealed class LocalStreamProviderPlugin : IStreamProviderPlugin
{
    public PluginDescriptor Descriptor { get; } = new(
        "mediapager.stream.local",
        "Local",
        "0.1.0",
        "Nobugsgiven",
        "Official local stream provider for catalog-backed media.");

    public StreamProviderMode Mode => StreamProviderMode.Local;

    public IReadOnlyList<MediaKind> SupportedKinds { get; } =
    [
        MediaKind.Movie,
        MediaKind.Tv,
        MediaKind.Music,
        MediaKind.Podcast,
        MediaKind.Audiobook,
        MediaKind.Book,
    ];

    public IReadOnlyList<SourceDescriptor> Sources { get; } = [];

    public Task<Paged<BrowseItem>> BrowseAsync(string sourceKey, string? query, int page, CancellationToken cancellationToken) =>
        Task.FromResult<Paged<BrowseItem>>(new([]));

    public Task<TitleDetails?> GetDetailsAsync(string sourceKey, string externalId, CancellationToken cancellationToken) =>
        Task.FromResult<TitleDetails?>(null);

    public Task<StreamResult?> ResolveAsync(StreamResolveRequest request, CancellationToken cancellationToken) =>
        Task.FromResult<StreamResult?>(null);
}

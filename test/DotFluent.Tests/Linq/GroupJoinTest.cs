using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFluent.Linq
{
    [TestFixture]
    public sealed class GroupJoinTest
    {
        #region Fields

        private static readonly List<Artist> _artists = new List<Artist>();
        private static readonly List<Album> _albums = new List<Album>();

        #endregion

        #region Methods

        [OneTimeSetUp]
        public static void Initialize()
        {
            _artists.Add(new Artist()
            {
                Id = 1,
                Name = "Artist One"
            });
            _artists.Add(new Artist()
            {
                Id = 2,
                Name = "Artist Two"
            });
            _artists.Add(new Artist()
            {
                Id = 3,
                Name = "Artist Three"
            });

            _albums.Add(new Album()
            {
                Id = 1,
                ArtistId = 1,
                Name = "Album One"
            });
            _albums.Add(new Album()
            {
                Id = 2,
                ArtistId = 2,
                Name = "Album Two"
            });
            _albums.Add(new Album()
            {
                Id = 3,
                ArtistId = 2,
                Name = "Album Three"
            });
        }

        [Test]
        public void OuterNullThrowsException()
        {
            IEnumerable<Artist> artists = null;

            Assert.Throws<ArgumentNullException>(() => artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void InnerNullThrowsException()
        {
            IEnumerable<Album> albums = null;

            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void OuterKeySelectorNullThrowsException()
        {
            Func<Artist, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, keySelector, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, keySelector, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void InnerKeySelectorNullThrowsException()
        {
            Func<Album, int> keySelector = null;

            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, keySelector, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, keySelector, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ResultSelectorNullThrowsException()
        {
            Func<Artist, IEnumerable<Album>, object> resultSelector = null;

            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, resultSelector, (x, y) => x == y));
            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, resultSelector, (x, y) => x == y, x => x.GetHashCode()));
        }

        [Test]
        public void ComparerNullThrowsException()
        {
            Func<int, int, bool> comparer = null;

            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, comparer));
            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, comparer, x => x.GetHashCode()));
        }

        [Test]
        public void HashCodeProviderNullThrowsException()
        {
            Func<int, int> hashCodeProvider = null;

            Assert.Throws<ArgumentNullException>(() => _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y, hashCodeProvider));
        }

        [Test]
        public void GroupJoin()
        {
            var groups = _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y).ToArray();
            Assert.AreEqual(groups.Length, 3);

            var albumCounts = new[] { 1, 2, 0 };
            for (var i = 0; i < groups.Length; i++)
            {
                var group = groups[i];
                var count = group.Albums.Count();
                Assert.IsTrue(count == albumCounts[i]);
                Assert.IsTrue(group.Albums.All(x => x.ArtistId == group.Artist.Id));
            }
        }

        [Test]
        public void GroupJoinWithHashCode()
        {
            var hash = GetHashCode();
            var groups = _artists.GroupJoin(_albums, x => x.Id, x => x.ArtistId, (a, ie) => new { Artist = a, Albums = ie }, (x, y) => x == y, x => x.GetHashCode() ^ hash).ToArray();
            Assert.AreEqual(groups.Length, 3);

            var albumCounts = new[] { 1, 2, 0 };
            for (var i = 0; i < groups.Length; i++)
            {
                var group = groups[i];
                var count = group.Albums.Count();
                Assert.AreEqual(count, albumCounts[i]);
                Assert.IsTrue(group.Albums.All(x => x.ArtistId == group.Artist.Id));
            }
        }

        #endregion

        #region Nested Classes

        private sealed class Artist
        {
            #region Properties

            public int Id { get; set; }

            public string Name { get; set; }

            #endregion
        }

        private sealed class Album
        {
            #region Properties

            public int Id { get; set; }

            public int ArtistId { get; set; }

            public string Name { get; set; }

            #endregion
        }

        #endregion
    }
}

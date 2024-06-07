namespace Core.LockManager
{
    public interface ILockManager
    {
        /// <summary>
        /// Checks the operation key whether is locked or not.
        /// </summary>
        /// <param name="key">The operation name, for example: filling.</param>
        /// <returns>True if the operation is previously locked and false if it isn't locked..</returns>
        Task<bool> IsLockedAsync(string key);

        /// <summary>
        /// Try to lock the operation key.
        /// </summary>
        /// <param name="key">The operation name, for example: filling.</param>
        /// <param name="duration">Locking lifetime</param>
        /// <returns>True if the operation is previously locked and false if it has locked now.</returns>
        Task<bool> TryToLockAsync(string key, TimeSpan? duration = null);

        /// <summary>
        /// Try to remove locked key.
        /// </summary>
        /// <param name="key">The operation name, for example: filling.</param>
        /// <returns>True if key successfully removed</returns>
        public bool TryToUnlock(string key);
    }
}
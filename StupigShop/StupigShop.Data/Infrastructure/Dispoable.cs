﻿using System;

namespace StupigShop.Data.Infrastructure
{
    public class Dispoable : IDisposable
    {
        private bool isDisposed;

        ~Dispoable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
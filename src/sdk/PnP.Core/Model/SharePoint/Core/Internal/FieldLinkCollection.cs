﻿using System;
using System.Threading.Tasks;
using PnP.Core.Services;

namespace PnP.Core.Model.SharePoint
{
    internal partial class FieldLinkCollection
    {
        public async Task<IFieldLink> AddBatchAsync(string fieldInternalName, string displayName = null, bool hidden = false, bool required = false, bool readOnly = false, bool showInDisplayForm = true)
        {
            return await AddBatchAsync(PnPContext.CurrentBatch, fieldInternalName, displayName, hidden, required, readOnly, showInDisplayForm).ConfigureAwait(false);
        }

        public async Task<IFieldLink> AddBatchAsync(Batch batch, string fieldInternalName, string displayName = null, bool hidden = false, bool required = false, bool readOnly = false, bool showInDisplayForm = true)
        {
            if (string.IsNullOrEmpty(fieldInternalName))
            {
                throw new ArgumentNullException(nameof(fieldInternalName));
            }

            var newFieldLink = CreateNewAndAdd() as FieldLink;

            newFieldLink.FieldInternalName = fieldInternalName;
            newFieldLink.DisplayName = displayName;
            newFieldLink.Hidden = hidden;
            newFieldLink.Required = required;
            newFieldLink.ReadOnly = readOnly;
            newFieldLink.ShowInDisplayForm = showInDisplayForm;

            return await newFieldLink.AddBatchAsync(batch).ConfigureAwait(false) as FieldLink;
        }

        public async Task<IFieldLink> AddAsync(string fieldInternalName, string displayName = null, bool hidden = false, bool required = false, bool readOnly = false, bool showInDisplayForm = true)
        {
            if (string.IsNullOrEmpty(fieldInternalName))
            {
                throw new ArgumentNullException(nameof(fieldInternalName));
            }

            var newFieldLink = CreateNewAndAdd() as FieldLink;

            newFieldLink.FieldInternalName = fieldInternalName;
            newFieldLink.DisplayName = displayName;
            newFieldLink.Hidden = hidden;
            newFieldLink.Required = required;
            newFieldLink.ReadOnly = readOnly;
            newFieldLink.ShowInDisplayForm = showInDisplayForm;

            return await newFieldLink.AddAsync().ConfigureAwait(false) as FieldLink;
        }
    }
}